using SchoolNotes.API.Models;

namespace SchoolNotes.API.Services;

public class CourseService(IUnitOfWork unitOfWork)
    : GenericService<Course, Guid>(unitOfWork, unitOfWork.CourseRepository)
{

}
