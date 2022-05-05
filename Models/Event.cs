using System.ComponentModel.DataAnnotations.Schema;

public class Event
{

    public Event(DateTime Date, int CourseId, int LeagueId) 
    {
        this.Date = Date;
        this.CourseId = CourseId;
        this.LeagueId = LeagueId;
    }
    public int Id { get; set; }
    public DateTime Date { get; set; }
    [ForeignKey("Course")]
    public int CourseId { get; set; }
    [ForeignKey("League")]
    public int LeagueId { get; set; }

    public virtual League League { get; set; }
    public virtual Course Course { get; set; }
}