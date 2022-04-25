using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace golf_leagues_identity.Models;

public class Player
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Handicap { get; set; }
    public List<League> Leagues { get; set; }
}