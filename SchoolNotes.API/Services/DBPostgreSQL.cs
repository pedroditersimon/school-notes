using Microsoft.EntityFrameworkCore;
using SchoolNotes.API.Models;

namespace SchoolNotes.API.Services;

public class DBPostgreSQL : DbContext
{
    public DBPostgreSQL(DbContextOptions<DBPostgreSQL> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // dont include Soft deleted entities in any queries
        modelBuilder.Entity<Student>().HasQueryFilter(t => !t.IsDeleted);
        modelBuilder.Entity<Note>().HasQueryFilter(t => !t.IsDeleted);
        modelBuilder.Entity<Course>().HasQueryFilter(t => !t.IsDeleted);
    }
}
