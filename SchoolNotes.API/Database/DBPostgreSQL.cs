using Microsoft.EntityFrameworkCore;
using SchoolNotes.API.Database.Seeds;
using SchoolNotes.API.Models;

namespace SchoolNotes.API.Database;

public class DBPostgreSQL : DbContext
{
    public DBPostgreSQL(DbContextOptions<DBPostgreSQL> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // dont include Soft deleted entities in any queries
        modelBuilder.Entity<Course>().HasQueryFilter(t => !t.IsDeleted);
        modelBuilder.Entity<CourseSession>().HasQueryFilter(t => !t.IsDeleted);
        modelBuilder.Entity<Student>().HasQueryFilter(t => !t.IsDeleted);
        modelBuilder.Entity<Score>().HasQueryFilter(t => !t.IsDeleted);

        // Seeds
        modelBuilder.ApplyConfiguration(new StudentSeed());
        modelBuilder.ApplyConfiguration(new CourseSeed());
        modelBuilder.ApplyConfiguration(new CourseSessionSeed());
        modelBuilder.ApplyConfiguration(new CourseSessionStudentSeed());
        modelBuilder.ApplyConfiguration(new ScoreSeed());
    }
}
