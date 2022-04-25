using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Duende.IdentityServer.EntityFramework.Options;
using golf_leagues_identity.Models;

namespace golf_leagues_identity.Models;

public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions options, IOptions<OperationalStoreOptions> operationalStoreOptions)
        : base(options, operationalStoreOptions)
    {
        
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

        builder.Entity<Player>()
            .HasKey(p => p.Id);
        builder.Entity<Player>()
            .HasIndex(p => p.Id)
            .IsUnique();
        builder.Entity<Player>()
            .Property(p => p.FirstName).HasMaxLength(30);
        builder.Entity<Player>()
            .Property(p => p.LastName).HasMaxLength(30);
    }

    public DbSet<League> League { get; set; }
}
