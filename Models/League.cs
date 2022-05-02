namespace golf_leagues_identity.Models;

public class League
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public virtual ICollection<Player> Players { get; set; }
    public virtual ICollection<Event> Events { get; set; }
}