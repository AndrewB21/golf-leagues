using golf_leagues_identity.Models;
using Microsoft.EntityFrameworkCore;
namespace golf_leagues_identity.Services
{
    public class LeagueService : ILeagueService
    {
        private readonly ApplicationDbContext dbContext;

        public LeagueService(ApplicationDbContext ApplicationDbContext)
        {
            this.dbContext = ApplicationDbContext;
        }

        public List<League> GetAll()
        {
            return this.dbContext.League.Include(l => l.Players).Include(l => l.Events).ThenInclude(e => e.Course).ToList();
        }

         public League GetLeagueById(int id)
        {
            return this.dbContext.League.Include(l => l.Players).Include(l => l.Events).ThenInclude(e => e.Course).FirstOrDefault(l => l.Id == id);
        }

        public League CreateLeague(League newLeague)
        {
            this.dbContext.League.Add(newLeague);
            this.dbContext.SaveChanges();
            return newLeague;
        }
    }

    public interface ILeagueService
    {
        List<League> GetAll();
        League GetLeagueById(int id);
        League CreateLeague(League newLeague);
    }
}