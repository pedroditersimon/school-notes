﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolNotes.API.Database;
using SchoolNotes.API.Repositories;
using SchoolNotes.API.Services;

namespace SchoolNotes.Test;

internal static class TestsHelper
{
    public static readonly Guid GUID01 = Guid.Parse("00000000-0000-0000-0000-000000000001");
    public static readonly Guid GUID02 = Guid.Parse("00000000-0000-0000-0000-000000000002");
    public static readonly Guid GUID03 = Guid.Parse("00000000-0000-0000-0000-000000000003");
    public static readonly Guid GUID04 = Guid.Parse("00000000-0000-0000-0000-000000000003");

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

    public static T ReturnValue<T>(this ActionResult<T> result)
    {
        return result.Result == null ? result.Value : (T)((ObjectResult)result.Result).Value;
    }
}
