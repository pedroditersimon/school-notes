using Microsoft.EntityFrameworkCore;
using SchoolNotes.API.Database;
using SchoolNotes.API.Models;

namespace SchoolNotes.API.Repositories;

public class ContactRepository(DBPostgreSQL dbContext)
    : Repository<Contact, Guid>(dbContext)
{

    public IQueryable<Contact> SearchByDNI(string dni)
        => Entities.Where(c => c.DNI.Contains(dni));

    public async Task<Contact?> GetByDNI(string dni)
        => await Entities.SingleOrDefaultAsync(c => c.DNI.Equals(dni));

}
