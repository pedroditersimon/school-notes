using SchoolNotes.API.Models;
using SchoolNotes.API.Repositories;

namespace SchoolNotes.API.Services;

public class CourseService(IUnitOfWork unitOfWork)
    : GenericService<Course, Guid, CourseRepository>(unitOfWork, unitOfWork.CourseRepository)
{

}
