using SchoolNotes.API.Models;
using SchoolNotes.API.Repositories.Interfaces;

namespace SchoolNotes.API.Services;

public class CourseService(IUnitOfWork unitOfWork)
    : GenericService<Course, Guid, ICourseRepository>(unitOfWork, unitOfWork.CourseRepository)
{

}
