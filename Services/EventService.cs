namespace golf_leagues_identity.Services
{
    public class EventService : IEventService
    {
        private readonly ApplicationDbContext dbContext;

        public EventService(ApplicationDbContext ApplicationDbContext)
        {
            this.dbContext = ApplicationDbContext;
        }

        public List<Event> GetAll()
        {
            return this.dbContext.Event.Include(e => e.Course).ToList();
        }

        public Event CreateEvent(Event newEvent)
        {
            this.dbContext.Add(newEvent);
            this.dbContext.SaveChanges();
            Event newEventFromDb = this.dbContext.Event.Include(e => e.Course).First(e => e.Id == newEvent.Id);
            return newEvent;
        }

        public Event UpdateEvent(Event updatedEvent)
        {
            Event eventInDb = this.dbContext.Event.Include(e => e.Course).First(e => e.Id == updatedEvent.Id);
            this.dbContext.Entry(eventInDb).CurrentValues.SetValues(updatedEvent);
            this.dbContext.SaveChanges();
            Event updatedEventFromDb = this.dbContext.Event.Include(e => e.Course).First(e => e.Id == updatedEvent.Id);
            return updatedEventFromDb;
        }
    }

    public interface IEventService
    {
        List<Event> GetAll();
        Event CreateEvent(Event newEvent);
        Event UpdateEvent(Event updatedEvent);
    }
}