
using Microsoft.EntityFrameworkCore;

namespace DEMO1.DataDBContext
{
    public class TrainingDBContext : DbContext
    {
        public TrainingDBContext(DbContextOptions<TrainingDBContext> options) : base(options)
        {

        }
        public DbSet<category> Categories{ get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Topic> Topics { get; set; }
    }
}
