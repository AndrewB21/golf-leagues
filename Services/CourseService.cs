namespace golf_leagues_identity.Services
{
    public class CourseService : ICourseService
    {
        private readonly ApplicationDbContext dbContext;

        public CourseService(ApplicationDbContext ApplicationDbContext)
        {
            this.dbContext = ApplicationDbContext;
        }

        public List<Course> GetAll()
        {
            return this.dbContext.Course.ToList();
        }

        
    }

    public interface ICourseService
    {
        List<Course> GetAll();
    }
}