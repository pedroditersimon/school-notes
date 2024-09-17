using SchoolNotes.API.Models;

namespace SchoolNotes.API.Repositories.Interfaces;

public interface IContactRepository : IRepository<Contact, Guid>
{
    public IQueryable<Contact> SearchByDNI(string dni);
    public Task<Contact?> GetByDNI(string dni);
}
