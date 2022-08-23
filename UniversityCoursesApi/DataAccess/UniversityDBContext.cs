using Microsoft.EntityFrameworkCore;
using UniversityCoursesApi.Models.DataModels;

namespace UniversityCoursesApi.DataAccess
{
    public class UniversityDBContext: DbContext
    {
        public UniversityDBContext(DbContextOptions<UniversityDBContext> options): base(options)
        {

        }
        // Add DbSets (creates Tables inside the DB
        public DbSet<User>? Users{ get; set; }
        public DbSet<Course>? Courses { get; set; }
        public DbSet<Chapter> Chapters { get; set; }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Student> Students { get; set; }
        
    }
}
