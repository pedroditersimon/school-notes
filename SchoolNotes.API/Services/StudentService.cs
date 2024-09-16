using Microsoft.EntityFrameworkCore;
using SchoolNotes.API.Models;
using SchoolNotes.API.Repositories;

namespace SchoolNotes.API.Services;

public class StudentService : GenericService<Student, Guid, StudentRepository>
{

    public StudentService(IUnitOfWork unitOfWork) :
         base(unitOfWork, unitOfWork.StudentRepository)
    {

    }

    public IQueryable<Student> GetByCourseSessionID(Guid courseSessionID)
    {
        IQueryable<CourseSessionStudent> courseSessionStudents = _unitOfWork.CourseSessionStudentRepository.GetByCourseSessionID(courseSessionID);
        return courseSessionStudents
            .Include(cst => cst.Student)
            .Select(cst => cst.Student);
    }

}
