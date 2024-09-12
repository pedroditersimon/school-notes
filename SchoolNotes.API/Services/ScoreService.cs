using SchoolNotes.API.Models;

namespace SchoolNotes.API.Services;

public class ScoreService(IUnitOfWork unitOfWork)
    : GenericService<Score, Guid>(unitOfWork, unitOfWork.ScoreRepository)
{

}