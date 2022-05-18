namespace golf_leagues_identity.Services
{
    public class LeagueService : ILeagueService
    {
        private readonly ApplicationDbContext dbContext;

        public LeagueService(ApplicationDbContext ApplicationDbContext)
        {
            this.dbContext = ApplicationDbContext;
        }

        public Task<List<League>> GetAll()
        {
            return this.dbContext.League
                .Include(l => l.Players)
                .ThenInclude(p => p.PlayerPoints)
                .Include(l => l.Events)
                .ThenInclude(e => e.Course)
                .ToListAsync();
        }

         public League GetLeagueById(int id)
        {
            return this.dbContext.League
                .Include(l => l.Players)
                .ThenInclude(p => p.PlayerPoints)
                .Include(l => l.Events)
                .ThenInclude(e => e.Course)
                .First(l => l.Id == id);
        }

        public League CreateLeague(League newLeague)
        {
            this.dbContext.League.Add(newLeague);
            this.dbContext.SaveChanges();
            return newLeague;
        }

        public League UpdateLeague(League updatedLeague)
        {
            League leagueInDb = GetLeagueById(updatedLeague.Id);
            this.dbContext.Entry(leagueInDb).CurrentValues.SetValues(updatedLeague);
            this.dbContext.SaveChanges();
            return leagueInDb;
        }

        public League DeleteLeague(int leagueId)
        {
            League leagueInDb = this.dbContext.League.FirstOrDefault(l => l.Id == leagueId);
            this.dbContext.League.Remove(leagueInDb);
            this.dbContext.SaveChanges();
            return leagueInDb;
        }
    }

    public interface ILeagueService
    {
        Task<List<League>> GetAll();
        League GetLeagueById(int id);
        League CreateLeague(League newLeague);
        League UpdateLeague(League updatedLeague);
        League DeleteLeague(int leagueId);
    }
}