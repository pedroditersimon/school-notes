using Microsoft.EntityFrameworkCore;
using SchoolNotes.API.Database;
using SchoolNotes.API.Models;
using SchoolNotes.API.Repositories.Interfaces;

namespace SchoolNotes.API.Repositories;

public class ContactRepository
    : Repository<Contact, Guid>, IContactRepository
{

    public ContactRepository(SchoolNotesDbContext dbContext)
        : base(dbContext)
    {
    }

    public IQueryable<Contact> SearchByDNI(string dni)
        => Entities.Where(c => c.DNI.Contains(dni));

    public async Task<Contact?> GetByDNI(string dni)
        => await Entities.SingleOrDefaultAsync(c => c.DNI.Equals(dni));

}
