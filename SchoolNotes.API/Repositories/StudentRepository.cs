using Microsoft.EntityFrameworkCore;
using SchoolNotes.API.Database;
using SchoolNotes.API.Models;

namespace SchoolNotes.API.Repositories;

public class StudentRepository(DBPostgreSQL dbContext) : Repository<Student, Guid>(dbContext)
{
    public override async Task<Student?> GetByID(Guid id)
        => await Entities.Include(s => s.Contact).SingleOrDefaultAsync(s => s.ID.Equals(id));
}
