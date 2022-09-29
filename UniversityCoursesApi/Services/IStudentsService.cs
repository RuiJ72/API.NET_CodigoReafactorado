using UniversityCoursesApi.Models.DataModels;

namespace UniversityCoursesApi.Services
{
    public interface IStudentsService
    {
        IEnumerable<Student> GetStudentsWithCourses();
        IEnumerable<Student> GetStudentsWithNoCourses();



    }
}
