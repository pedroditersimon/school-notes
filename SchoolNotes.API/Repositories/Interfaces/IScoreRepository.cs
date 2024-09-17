using SchoolNotes.API.Models;

namespace SchoolNotes.API.Repositories.Interfaces;

public interface IScoreRepository : IRepository<Score, Guid>
{
    public IQueryable<Score> GetByCourseSessionID(Guid courseSessionID);
    public IQueryable<Score> GetByStudentID(Guid studentID);
}
