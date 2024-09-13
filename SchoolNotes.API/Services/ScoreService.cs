using SchoolNotes.API.Models;
using SchoolNotes.API.Repositories;

namespace SchoolNotes.API.Services;

public class ScoreService(IUnitOfWork unitOfWork)
    : GenericService<Score, Guid>(unitOfWork, unitOfWork.ScoreRepository)
{
    public IQueryable<Score> GetByCourseSessionID(Guid courseSessionID)
        => ((ScoreRepository)_repository).GetByCourseSessionID(courseSessionID);

    public IQueryable<Score> GetByStudentID(Guid studentID)
        => ((ScoreRepository)_repository).GetByStudentID(studentID);
}
