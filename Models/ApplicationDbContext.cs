using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Duende.IdentityServer.EntityFramework.Options;

namespace golf_leagues_identity.Models;

public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions options, IOptions<OperationalStoreOptions> operationalStoreOptions)
        : base(options, operationalStoreOptions)
    {
        this.ChangeTracker.LazyLoadingEnabled = false;
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.HasDefaultSchema("golf_league");

        builder.Entity<League>()
            .HasKey(l => l.Id);
        builder.Entity<League>()
            .HasIndex(l => l.Id)
            .IsUnique();
        builder.Entity<League>()
            .Property(l => l.Name).HasMaxLength(50);
        builder.Entity<League>()
            .Property(l => l.Description).HasMaxLength(200);
        builder.Entity<League>()
            .HasMany(l => l.Players)
            .WithMany(p => p.Leagues);
        builder.Entity<League>()
            .HasMany(l => l.Events)
            .WithOne(e => e.League);

        builder.Entity<Player>()
            .HasKey(p => p.Id);
        builder.Entity<Player>()
            .HasIndex(p => p.Id)
            .IsUnique();
        builder.Entity<Player>()
            .Property(p => p.FirstName).HasMaxLength(30);
        builder.Entity<Player>()
            .Property(p => p.LastName).HasMaxLength(30);
        
        builder.Entity<Event>()
            .HasKey(e => e.Id);
        builder.Entity<Event>()
            .HasIndex(e => e.Id)
            .IsUnique();
        
        builder.Entity<Course>()
            .HasKey(c => c.Id);
        builder.Entity<Course>()
            .HasIndex(c => c.Id)
            .IsUnique();
    }

    public DbSet<League> League { get; set; }
    public DbSet<Player> Player { get; set; }
    public DbSet<Event> Event { get; set; }
    public DbSet<Course> Course { get; set; }
}
