namespace golf_leagues_identity.Models;

public class Course
{

    public Course(string Name, string Address) 
    {
        this.Name = Name;
        this.Address = Address;
    }
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
}