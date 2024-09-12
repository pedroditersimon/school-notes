using SchoolNotes.API.Database;
using SchoolNotes.API.Models;

namespace SchoolNotes.API.Repositories;

public class CourseSessionStudentRepository(DBPostgreSQL dbContext) : Repository<CourseSessionStudent, Guid>(dbContext)
{

    public IQueryable<CourseSessionStudent> GetByStudentID(Guid studentID)
        => Entities.Where(cst => cst.StudentID.Equals(studentID));

    public IQueryable<CourseSessionStudent> GetByCourseSessionID(Guid courseSessionID)
        => Entities.Where(cst => cst.CourseSessionID.Equals(courseSessionID));

}
