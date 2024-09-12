using SchoolNotes.API.Database;
using SchoolNotes.API.Models;

namespace SchoolNotes.API.Repositories;

public class CourseSessionRepository(DBPostgreSQL dbContext) :
    Repository<CourseSession, Guid>(dbContext)
{

}
