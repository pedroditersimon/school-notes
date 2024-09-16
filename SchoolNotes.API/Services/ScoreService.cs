using SchoolNotes.API.Models;
using SchoolNotes.API.Repositories;

namespace SchoolNotes.API.Services;

public class ScoreService : GenericService<Score, Guid, ScoreRepository>
{

    public ScoreService(IUnitOfWork unitOfWork)
        : base(unitOfWork, unitOfWork.ScoreRepository)
    {

    }

    public IQueryable<Score> GetByCourseSessionID(Guid courseSessionID)
        => _repository.GetByCourseSessionID(courseSessionID);

    public IQueryable<Score> GetByStudentID(Guid studentID)
        => _repository.GetByStudentID(studentID);
}
