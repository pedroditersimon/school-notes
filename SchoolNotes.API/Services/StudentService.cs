using Microsoft.EntityFrameworkCore;
using SchoolNotes.API.Models;

namespace SchoolNotes.API.Services;

public class StudentService(IUnitOfWork unitOfWork)
    : GenericService<Student, Guid>(unitOfWork, unitOfWork.StudentRepository)
{

    public IQueryable<Student> GetByCourseSessionID(Guid courseSessionID)
    {
        IQueryable<CourseSessionStudent> courseSessionStudents = _unitOfWork.CourseSessionStudentRepository.GetByCourseSessionID(courseSessionID);
        return courseSessionStudents
            .Include(cst => cst.Student)
            .Select(cst => cst.Student);
    }

}
