namespace golf_leagues_identity.Models;

public class Player
{

    public Player(string FirstName, string LastName, int Handicap) 
    {
        this.FirstName = FirstName;
        this.LastName = LastName;
        this.Handicap = Handicap;
    }
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Handicap { get; set; }
    public virtual ICollection<League> Leagues { get; set; }
}