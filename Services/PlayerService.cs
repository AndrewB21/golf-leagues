namespace golf_leagues_identity.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly ApplicationDbContext dbContext;

        public PlayerService(ApplicationDbContext ApplicationDbContext)
        {
            this.dbContext = ApplicationDbContext;
        }

        public List<Player> GetAll()
        {
            return this.dbContext.Player.Include(p => p.Leagues).Include(p => p.PlayerPoints).ToList();
        }

         public Player GetPlayerById(int id)
        {
            return this.dbContext.Player.Include(p => p.Leagues).Include(p => p.PlayerPoints).FirstOrDefault(l => l.Id == id);
        }

        public Player CreatePlayer(Player newPlayer)
        {
            // Create a new Player object without Leagues/PlayerPoints to add to the Players table
            Player playerDto = new Player(newPlayer.FirstName, newPlayer.LastName, newPlayer.Handicap);
            playerDto.PlayerPoints = new List<PlayerPoints>();
            this.dbContext.Player.Add(playerDto);
            this.dbContext.SaveChanges();

            // Add the new player to each league stored on the original newPlayer object
            foreach(League league in newPlayer.Leagues)
            {
                League leagueFromDb = this.dbContext.League.Include(l => l.Players).FirstOrDefault(l => l.Id == league.Id);
                if (leagueFromDb != null)
                {
                    leagueFromDb.Players.Add(playerDto);
                    int points = newPlayer.PlayerPoints.First(p => p.LeagueId == league.Id).Points;
                    PlayerPoints playerPoints = new PlayerPoints(playerDto.Id, leagueFromDb.Id, points);
                    playerDto.PlayerPoints.Add(playerPoints);
                }
            }
            this.dbContext.SaveChanges();
            newPlayer = this.dbContext.Player.Include(p => p.Leagues).Include(p => p.PlayerPoints).First(p => p.Id == playerDto.Id);
            return newPlayer;
        }

        public Player UpdatePlayer(Player updatedPlayer)
        {
            Player playerInDb = this.dbContext.Player.Include(p => p.PlayerPoints).First(p => p.Id == updatedPlayer.Id);
            this.dbContext.Entry(playerInDb).CurrentValues.SetValues(updatedPlayer);
            // update points records, better way to do this maybe?? 
            foreach (PlayerPoints pointsEntry in updatedPlayer.PlayerPoints)
            {
                PlayerPoints entryInDb = this.dbContext.PlayerPoints.First(p => p.Id == pointsEntry.Id);
                if (entryInDb != null)
                {
                    this.dbContext.Entry(entryInDb).CurrentValues.SetValues(pointsEntry);
                    entryInDb = this.dbContext.PlayerPoints.First(p => p.Id == pointsEntry.Id);
                }
            }
            this.dbContext.SaveChanges();
            return updatedPlayer;
        }

        public Player RemovePlayerFromLeague(int playerId, int leagueId)
        {
            League league = this.dbContext.League.Include(l => l.Players).First(l => l.Id == leagueId);
            Player player = this.dbContext.Player.First(p => p.Id == playerId);
            league.Players.Remove(player);
            this.dbContext.SaveChanges();
            return player;
        }

        public Player DeletePlayer(int playerId)
        {
            Player playerInDb = this.dbContext.Player.FirstOrDefault(p => p.Id == playerId);
            this.dbContext.Player.Remove(playerInDb);
            this.dbContext.SaveChanges();
            return playerInDb;
        }
    }

    public interface IPlayerService
    {
        List<Player> GetAll();
        Player GetPlayerById(int id);
        Player CreatePlayer(Player newPlayer);
        Player UpdatePlayer(Player updatedPlayer);
        Player RemovePlayerFromLeague(int playerId, int leagueId);
        Player DeletePlayer(int playerId);
    }
}