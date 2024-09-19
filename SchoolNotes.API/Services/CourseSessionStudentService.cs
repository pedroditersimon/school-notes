using Microsoft.EntityFrameworkCore;
using SchoolNotes.API.Models;
using SchoolNotes.API.Repositories.Interfaces;

namespace SchoolNotes.API.Services;

public class CourseSessionStudentService : GenericService<CourseSessionStudent, Guid, ICourseSessionStudentRepository>
{

    public CourseSessionStudentService(IUnitOfWork unitOfWork) :
        base(unitOfWork, unitOfWork.CourseSessionStudentRepository)
    {

    }


    public async Task<List<CourseSessionStudent>> GetByStudentID(Guid id)
    {
        IQueryable<CourseSessionStudent> courseSessionStudents = _unitOfWork.CourseSessionStudentRepository.GetByStudentID(id);
        return await courseSessionStudents.ToListAsync();
    }

    public async Task<List<CourseSessionStudent>> GetByCourseSessionID(Guid id)
    {
        IQueryable<CourseSessionStudent> courseSessionStudents = _unitOfWork.CourseSessionStudentRepository.GetByCourseSessionID(id);
        return await courseSessionStudents.ToListAsync();
    }

}