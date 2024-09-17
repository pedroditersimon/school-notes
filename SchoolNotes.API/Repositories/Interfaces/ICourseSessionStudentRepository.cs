using SchoolNotes.API.Models;

namespace SchoolNotes.API.Repositories.Interfaces;

public interface ICourseSessionStudentRepository : IRepository<CourseSessionStudent, Guid>
{
    public IQueryable<CourseSessionStudent> GetByStudentID(Guid studentID);

    public IQueryable<CourseSessionStudent> GetByCourseSessionID(Guid courseSessionID);

}
