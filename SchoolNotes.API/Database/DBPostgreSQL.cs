using Microsoft.EntityFrameworkCore;
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

        modelBuilder.Entity<CourseSessionStudents>()
            .HasKey(cst => new { cst.CourseSessionID, cst.StudentID });

        modelBuilder.Entity<CourseSessionStudents>()
            .HasOne(cst => cst.CourseSession)
            .WithMany(cs => cs.CourseSessionStudents)
            .HasForeignKey(cst => cst.CourseSessionID);

        modelBuilder.Entity<CourseSessionStudents>()
            .HasOne(cst => cst.Student)
            .WithMany(s => s.CourseSessionStudents)
            .HasForeignKey(cst => cst.StudentID);

        modelBuilder.Entity<Score>()
            .HasOne(sc => sc.CourseSessionStudent)
            .WithMany(cst => cst.Scores)
            .HasForeignKey(sc => new { sc.CourseSessionID, sc.StudentID });
    }
}
