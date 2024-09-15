using Microsoft.EntityFrameworkCore;
using SchoolNotes.API.Database.Seeds;
using SchoolNotes.API.Models;

namespace SchoolNotes.API.Database;

public class DBPostgreSQL : DbContext
{
    public DBPostgreSQL(DbContextOptions<DBPostgreSQL> options) : base(options)
    {

    }

    protected override async void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Seeds
        modelBuilder.ApplyConfiguration(new ContactSeed());
        modelBuilder.ApplyConfiguration(new StudentSeed());
        modelBuilder.ApplyConfiguration(new TeacherSeed());
        modelBuilder.ApplyConfiguration(new CourseSeed());
        modelBuilder.ApplyConfiguration(new CourseSessionSeed());
        modelBuilder.ApplyConfiguration(new CourseSessionStudentSeed());
        modelBuilder.ApplyConfiguration(new ScoreSeed());


        // dont include Soft deleted entities in any queries
        modelBuilder.Entity<Course>().HasQueryFilter(t => !t.IsDeleted);
        modelBuilder.Entity<CourseSession>().HasQueryFilter(t => !t.IsDeleted);
        modelBuilder.Entity<Student>().HasQueryFilter(t => !t.IsDeleted);
        modelBuilder.Entity<Teacher>().HasQueryFilter(t => !t.IsDeleted);
        modelBuilder.Entity<Score>().HasQueryFilter(t => !t.IsDeleted);
    }
}
