using System.ComponentModel.DataAnnotations;

namespace UniversityCoursesApi.Models.DataModels
{
    public class Student : BaseEntity
    {
        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;
        
        [Required]
        public DateTime DateBirth { get; set; }

        public ICollection<Course> Courses { get; set; } = new List<Course>();

    }
}
