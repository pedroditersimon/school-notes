using SchoolNotes.API.Models;
using SchoolNotes.API.Repositories;

namespace SchoolNotes.API.Services;

public class ContactService(IUnitOfWork unitOfWork)
    : GenericService<Contact, Guid, ContactRepository>(unitOfWork, unitOfWork.ContactRepository)
{
    public IQueryable<Contact> SearchByDNI(string dni)
        => _repository.SearchByDNI(dni);

    public async Task<Contact?> GetByDNI(string dni)
     => await _repository.GetByDNI(dni);
}
