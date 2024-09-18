using Microsoft.EntityFrameworkCore;
using SchoolNotes.API.Database;
using SchoolNotes.API.Repositories;
using SchoolNotes.API.Services;

namespace SchoolNotes.Test;

internal static class TestsHelper
{
    public static SchoolNotesDbContext CreateInMemoryDBContext()
    {
        DbContextOptions<SchoolNotesDbContext> options = new DbContextOptionsBuilder<SchoolNotesDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        return new SchoolNotesDbContext(options);
    }

    public static IUnitOfWork CreateInMemoryUnitOfWork()
    {
        SchoolNotesDbContext dbContext = CreateInMemoryDBContext();

        return new UnitOfWork(dbContext,
            new ContactRepository(dbContext),
            new StudentRepository(dbContext),
            new TeacherRepository(dbContext),
            new CourseRepository(dbContext),
            new CourseSessionRepository(dbContext),
            new CourseSessionStudentRepository(dbContext),
            new ScoreRepository(dbContext)
        );
    }
}
