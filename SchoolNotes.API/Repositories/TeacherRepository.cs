using SchoolNotes.API.Database;
using SchoolNotes.API.Models;

namespace SchoolNotes.API.Repositories;

public class TeacherRepository : Repository<Teacher, Guid>
{
    public TeacherRepository(DBPostgreSQL dbContext)
        : base(dbContext)
    {

    }
}
