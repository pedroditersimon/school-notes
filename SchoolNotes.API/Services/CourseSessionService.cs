
using Microsoft.EntityFrameworkCore;
using SchoolNotes.API.Models;
using SchoolNotes.API.Repositories;

namespace SchoolNotes.API.Services;

public class CourseSessionService : GenericService<CourseSession, Guid, CourseSessionRepository>
{

    public CourseSessionService(IUnitOfWork unitOfWork)
        : base(unitOfWork, unitOfWork.CourseSessionRepository)
    {

    }

    public IQueryable<CourseSession> GetByStudentID(Guid studentID)
    {
        IQueryable<CourseSessionStudent> courseSessionStudents = _unitOfWork.CourseSessionStudentRepository.GetByStudentID(studentID);

        return courseSessionStudents.Include(cst => cst.CourseSession).Include(cst => cst.CourseSession.Course).Select(cst => cst.CourseSession);
    }


    public IQueryable<CourseSession> GetByCourseID(Guid courseID)
    {
        IQueryable<CourseSession> courseSessions = _repository.GetAll();

        return courseSessions.Where(cs => cs.CourseID.Equals(courseID));
    }
}
