using Microsoft.EntityFrameworkCore;
using SchoolNotes.API.Models;
using SchoolNotes.API.Repositories.Interfaces;
namespace SchoolNotes.API.Services;

public class StudentService : GenericService<Student, Guid, IStudentRepository>
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

    public async Task<Student?> GetByContactDNI(string dni)
    {
        Contact? contact = await _unitOfWork.ContactRepository.GetByDNI(dni);
        if (contact == null)
            return null;

        return await GetByID(contact.ID);
    }

    public IQueryable<Student> SearchByContactDNI(string dni)
    {
        IQueryable<Contact> contacts = _unitOfWork.ContactRepository.SearchByDNI(dni);
        IQueryable<Student> students = _unitOfWork.StudentRepository.GetAll().Include(s => s.Contact);
        return students.Where(s => contacts.Contains(s.Contact));
    }
}
