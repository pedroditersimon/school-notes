using SchoolNotes.API.Database;
using SchoolNotes.API.Models;

namespace SchoolNotes.API.Repositories;

public class StudentRepository(DBPostgreSQL dbContext) : Repository<Student, Guid>(dbContext)
{

}
