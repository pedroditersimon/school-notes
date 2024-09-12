using SchoolNotes.API.Models;

namespace SchoolNotes.API.Services;

public class StudentService(IUnitOfWork unitOfWork)
    : GenericService<Student, Guid>(unitOfWork, unitOfWork.StudentRepository)
{

}
