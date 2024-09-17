using Microsoft.EntityFrameworkCore;
using SchoolNotes.API.Database;
using SchoolNotes.API.Models;
using SchoolNotes.API.Repositories.Interfaces;

namespace SchoolNotes.API.Repositories;

public class StudentRepository : Repository<Student, Guid>, IStudentRepository
{
    public StudentRepository(SchoolNotesDbContext dbContext)
        : base(dbContext)
    {

    }

    public override async Task<Student?> GetByID(Guid id)
        => await Entities.Include(s => s.Contact).SingleOrDefaultAsync(s => s.ID.Equals(id));
}
