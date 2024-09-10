using SchoolNotes.API.Models;
using SchoolNotes.API.Services;

namespace SchoolNotes.API.Repositories;

public class StudentRepository(DBPostgreSQL dbContext) : Repository<Student, Guid>(dbContext)
{

}
