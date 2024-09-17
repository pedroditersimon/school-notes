using SchoolNotes.API.Database;
using SchoolNotes.API.Models;
using SchoolNotes.API.Repositories.Interfaces;

namespace SchoolNotes.API.Repositories;

public class CourseSessionStudentRepository : Repository<CourseSessionStudent, Guid>, ICourseSessionStudentRepository
{
    public CourseSessionStudentRepository(SchoolNotesDbContext dbContext)
        : base(dbContext)
    {

    }

    public IQueryable<CourseSessionStudent> GetByStudentID(Guid studentID)
        => Entities.Where(cst => cst.StudentID.Equals(studentID));

    public IQueryable<CourseSessionStudent> GetByCourseSessionID(Guid courseSessionID)
        => Entities.Where(cst => cst.CourseSessionID.Equals(courseSessionID));

}
