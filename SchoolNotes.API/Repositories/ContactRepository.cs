using SchoolNotes.API.Database;
using SchoolNotes.API.Models;

namespace SchoolNotes.API.Repositories;

public class ContactRepository(DBPostgreSQL dbContext)
    : Repository<Contact, Guid>(dbContext)
{

}
