
using Microsoft.EntityFrameworkCore;
using SchoolNotes.API.Models;

namespace SchoolNotes.API.Services;

public class CourseSessionService(IUnitOfWork unitOfWork)
    : GenericService<CourseSession, Guid>(unitOfWork, unitOfWork.CourseSessionRepository)
{

    public IQueryable<CourseSession> GetByStudentID(Guid studentID)
    {
        IQueryable<CourseSessionStudent> courseSessionStudents = _unitOfWork.CourseSessionStudentRepository.GetByStudentID(studentID);

        return courseSessionStudents.Include(cst => cst.CourseSession).Select(cst => cst.CourseSession);
    }


    public IQueryable<CourseSession> GetByCourseID(Guid courseID)
    {
        IQueryable<CourseSession> courseSessions = _repository.GetAll();

        return courseSessions.Where(cs => cs.CourseID.Equals(courseID));
    }
}
