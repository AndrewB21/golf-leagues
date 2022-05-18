namespace golf_leagues_identity.Services
{
    public class CourseService : ICourseService
    {
        private readonly ApplicationDbContext dbContext;

        public CourseService(ApplicationDbContext ApplicationDbContext)
        {
            this.dbContext = ApplicationDbContext;
        }

        public Task<List<Course>> GetAll()
        {
            return this.dbContext.Course.ToListAsync();
        }

        
    }

    public interface ICourseService
    {
        Task<List<Course>> GetAll();
    }
}