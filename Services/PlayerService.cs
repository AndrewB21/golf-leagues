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
            // Create a new Player object without Leagues to add to the Players table
            Player playerDto = new Player(newPlayer.FirstName, newPlayer.LastName, newPlayer.Handicap);
            this.dbContext.Player.Add(playerDto);
            this.dbContext.SaveChanges();

            // Add the new player to each league stored on the original newPlayer object
            foreach(League league in newPlayer.Leagues)
            {
                League leagueFromDb = this.dbContext.League.Include(l => l.Players).FirstOrDefault(l => l.Id == league.Id);
                if (leagueFromDb != null)
                {
                    leagueFromDb.Players.Add(playerDto);
                }
            }
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