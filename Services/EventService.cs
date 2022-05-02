using golf_leagues_identity.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

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
            return newEvent;
        }

        
    }

    public interface IEventService
    {
        List<Event> GetAll();
        Event CreateEvent(Event newEvent);
    }
}