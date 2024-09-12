using SchoolNotes.API.Database;
using SchoolNotes.API.Models;

namespace SchoolNotes.API.Repositories;

public class CourseRepository(DBPostgreSQL dbContext) : Repository<Course, Guid>(dbContext)
{

}
