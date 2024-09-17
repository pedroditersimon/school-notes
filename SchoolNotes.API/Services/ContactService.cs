using SchoolNotes.API.Models;
using SchoolNotes.API.Repositories.Interfaces;

namespace SchoolNotes.API.Services;

public class ContactService(IUnitOfWork unitOfWork)
    : GenericService<Contact, Guid, IContactRepository>(unitOfWork, unitOfWork.ContactRepository)
{
    public IQueryable<Contact> SearchByDNI(string dni)
        => _repository.SearchByDNI(dni);

    public async Task<Contact?> GetByDNI(string dni)
     => await _repository.GetByDNI(dni);
}
