using SchoolNotes.API.Database;
using SchoolNotes.API.Models;
using SchoolNotes.API.Repositories.Interfaces;

namespace SchoolNotes.API.Repositories;

public class CourseSessionRepository : Repository<CourseSession, Guid>, ICourseSessionRepository
{
    public CourseSessionRepository(DBPostgreSQL dbContext)
        : base(dbContext)
    {

    }
}
