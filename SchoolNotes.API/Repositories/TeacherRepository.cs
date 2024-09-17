using SchoolNotes.API.Database;
using SchoolNotes.API.Models;
using SchoolNotes.API.Repositories.Interfaces;

namespace SchoolNotes.API.Repositories;

public class TeacherRepository : Repository<Teacher, Guid>, ITeacherRepository
{
    public TeacherRepository(SchoolNotesDbContext dbContext)
        : base(dbContext)
    {

    }
}
