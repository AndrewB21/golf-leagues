namespace golf_leagues_identity.Models;
using System.ComponentModel.DataAnnotations.Schema;

public class PlayerPoints
{

    public PlayerPoints(int PlayerId, int LeagueId, int Points) 
    {
        this.PlayerId = PlayerId;
        this.LeagueId = LeagueId;
        this.Points = Points;
    }
    public int Id { get; set; }
    [ForeignKey("Player")]
    public int PlayerId { get; set; }
    [ForeignKey("League")]
    public int LeagueId { get; set; }
    public int Points { get; set; }
    public virtual Player Player { get; set; }
    public virtual League League { get; set; }
}