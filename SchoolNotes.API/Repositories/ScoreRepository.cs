using SchoolNotes.API.Database;
using SchoolNotes.API.Models;

namespace SchoolNotes.API.Repositories;

public class ScoreRepository(DBPostgreSQL dbContext) : Repository<Score, Guid>(dbContext)
{
    public IQueryable<Score> GetByCourseSessionID(Guid courseSessionID)
        => Entities.Where(sc => sc.CourseSessionID.Equals(courseSessionID));


    public IQueryable<Score> GetByStudentID(Guid studentID)
        => Entities.Where(sc => sc.StudentID.Equals(studentID));

}
