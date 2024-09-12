using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolNotes.API.Models;

namespace SchoolNotes.API.Database.Seeds;

public class CourseSessionStudentSeed : IEntityTypeConfiguration<CourseSessionStudent>
{
    public void Configure(EntityTypeBuilder<CourseSessionStudent> builder)
    {
        builder.HasData(
            new CourseSessionStudent
            {
                ID = Guid.Parse("77777777-7777-7777-7777-777777777777"),
                CourseSessionID = Guid.Parse("44444444-4444-4444-4444-444444444444"), // Matematicas Session
                StudentID = Guid.Parse("00000000-0000-0000-0000-000000000001") // Maria Gonzalez
            },
            new CourseSessionStudent
            {
                ID = Guid.Parse("88888888-8888-8888-8888-888888888888"),
                CourseSessionID = Guid.Parse("55555555-5555-5555-5555-555555555555"), // Historia Session
                StudentID = Guid.Parse("00000000-0000-0000-0000-000000000002") // Juan Perez
            },
            new CourseSessionStudent
            {
                ID = Guid.Parse("99999999-9999-9999-9999-999999999999"),
                CourseSessionID = Guid.Parse("66666666-6666-6666-6666-666666666666"), // Ciencias Session
                StudentID = Guid.Parse("00000000-0000-0000-0000-000000000003") // Carlos Rodriguez
            }
        );

    }
}
