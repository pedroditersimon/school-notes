using SchoolNotes.API.Database;
using SchoolNotes.API.Models;
using SchoolNotes.API.Repositories.Interfaces;

namespace SchoolNotes.API.Repositories;

public class CourseRepository : Repository<Course, Guid>, ICourseRepository
{
    public CourseRepository(DBPostgreSQL dbContext) : base(dbContext)
    {

    }
}
