
using Microsoft.EntityFrameworkCore;
using SchoolNotes.API.Models;
using SchoolNotes.API.Repositories.Interfaces;

namespace SchoolNotes.API.Services;

public class CourseSessionService : GenericService<CourseSession, Guid, ICourseSessionRepository>
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


    public async Task<CourseSession?> AssignTeacher(Guid courseID, Guid teacherID)
    {
        CourseSession? courseSession = await _unitOfWork.CourseSessionRepository.GetByID(courseID);
        if (courseSession == null)
            return null;

        Teacher? teacher = await _unitOfWork.TeacherRepository.GetByID(teacherID);
        if (teacher == null)
            return null;

        courseSession.Teacher = teacher;
        return await _unitOfWork.CourseSessionRepository.Update(courseSession);
    }
}
