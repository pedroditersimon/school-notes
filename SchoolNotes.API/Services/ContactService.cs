using SchoolNotes.API.Models;
using SchoolNotes.API.Repositories;

namespace SchoolNotes.API.Services;

public class ContactService(IUnitOfWork unitOfWork)
    : GenericService<Contact, Guid, ContactRepository>(unitOfWork, unitOfWork.ContactRepository)
{
}
