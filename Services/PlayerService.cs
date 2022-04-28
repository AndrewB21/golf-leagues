using golf_leagues_identity.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

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
            return this.dbContext.Player.Include(p => p.Leagues).ToList();
        }

         public Player GetPlayerById(int id)
        {
            return this.dbContext.Player.FirstOrDefault(l => l.Id == id);
        }

        public Player CreatePlayer(Player newPlayer)
        {
            Player playerWithoutLeagues = new Player(newPlayer.FirstName, newPlayer.LastName, newPlayer.Handicap);
            playerWithoutLeagues.Leagues = new List<League>(newPlayer.Leagues);
            this.dbContext.Player.Add(playerWithoutLeagues);
            Console.WriteLine(playerWithoutLeagues.Id);
            this.dbContext.SaveChanges();
            return newPlayer;
        }
    }

    public interface IPlayerService
    {
        List<Player> GetAll();
        Player GetPlayerById(int id);
        Player CreatePlayer(Player newPlayer);
    }
}