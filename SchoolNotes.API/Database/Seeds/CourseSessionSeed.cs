using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolNotes.API.Models;

namespace SchoolNotes.API.Database.Seeds;

public class CourseSessionSeed : IEntityTypeConfiguration<CourseSession>
{
    public void Configure(EntityTypeBuilder<CourseSession> builder)
    {
        builder.HasData(
            new CourseSession
            {
                ID = Guid.Parse("44444444-4444-4444-4444-444444444444"),
                CourseID = Guid.Parse("11111111-1111-1111-1111-111111111111"), // Matematicas
                TeacherID = Guid.Parse("00000000-0000-0000-0000-000000000001"), // Pepito
                StartTime = DateTime.UtcNow.AddDays(1),
                EndTime = DateTime.UtcNow.AddDays(1).AddHours(2)
            },
            new CourseSession
            {
                ID = Guid.Parse("55555555-5555-5555-5555-555555555555"),
                CourseID = Guid.Parse("22222222-2222-2222-2222-222222222222"), // Historia
                TeacherID = Guid.Parse("00000000-0000-0000-0000-000000000001"), // Pepito
                StartTime = DateTime.UtcNow.AddDays(2),
                EndTime = DateTime.UtcNow.AddDays(2).AddHours(2)
            },
            new CourseSession
            {
                ID = Guid.Parse("66666666-6666-6666-6666-666666666666"),
                CourseID = Guid.Parse("33333333-3333-3333-3333-333333333333"), // Ciencias
                TeacherID = Guid.Parse("00000000-0000-0000-0000-000000000001"), // Pepito
                StartTime = DateTime.UtcNow.AddDays(3),
                EndTime = DateTime.UtcNow.AddDays(3).AddHours(2)
            }
        );

    }
}
