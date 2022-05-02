namespace golf_leagues_identity.Models;
public class LeaguePlayer
{
    public LeaguePlayer(int PlayersId, int LeaguesId) 
    {
        this.PlayersId = PlayersId;
        this.LeaguesId = LeaguesId;
    }
    public int Id { get; set; }
    public int PlayersId { get; set; }
    public int LeaguesId { get; set; }
}