using ODataDemo.Models;

namespace ODataDemo.Services
{
    public interface IStudentService
    {
        IQueryable<Student> RetrieveAllStudents();
    }
}
