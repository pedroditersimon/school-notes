using SchoolNotes.API.Database;
using SchoolNotes.API.Models;
using SchoolNotes.API.Repositories.Interfaces;

namespace SchoolNotes.API.Repositories;

public class ScoreRepository : Repository<Score, Guid>, IScoreRepository
{

    public ScoreRepository(SchoolNotesDbContext dbContext)
        : base(dbContext)
    {

    }

    public IQueryable<Score> GetByCourseSessionID(Guid courseSessionID)
        => Entities.Where(sc => sc.CourseSessionID.Equals(courseSessionID));


    public IQueryable<Score> GetByStudentID(Guid studentID)
        => Entities.Where(sc => sc.StudentID.Equals(studentID));

}
