using SchoolNotes.API.Models;
using SchoolNotes.API.Repositories;

namespace SchoolNotes.API.Services;

public class TeacherService : GenericService<Teacher, Guid, TeacherRepository>
{

    public TeacherService(IUnitOfWork unitOfWork)
        : base(unitOfWork, unitOfWork.TeacherRepository)
    {

    }

}
