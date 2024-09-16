using Microsoft.EntityFrameworkCore;
using SchoolNotes.API.Models;
using SchoolNotes.API.Repositories;

namespace SchoolNotes.API.Services;

public class TeacherService : GenericService<Teacher, Guid, TeacherRepository>
{

    public TeacherService(IUnitOfWork unitOfWork)
        : base(unitOfWork, unitOfWork.TeacherRepository)
    {

    }


    public async Task<Teacher?> GetByContactDNI(string dni)
    {
        Contact? contact = await _unitOfWork.ContactRepository.GetByDNI(dni);
        if (contact == null)
            return null;

        return await GetByID(contact.ID);
    }

    public IQueryable<Teacher> SearchByContactDNI(string dni)
    {
        IQueryable<Contact> contacts = _unitOfWork.ContactRepository.SearchByDNI(dni);
        IQueryable<Teacher> teachers = _unitOfWork.TeacherRepository.GetAll().Include(t => t.Contact);
        return teachers.Where(t => contacts.Contains(t.Contact));
    }
}
