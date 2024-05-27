using GAT_PROJECT.Entities;

namespace GAT_PROJECT.Repositories
{
    public interface ICourseCollection
    {
        Task InsertCourse(Course course);
        Task DeleteCourse(string id);
        Task UpdateCourse(Course course);
        Task<Course> GetCourseById(string id);
        Task<List<Course>> GetAllCourses();

    }
}
