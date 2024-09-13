using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolNotes.API.Models;

namespace SchoolNotes.API.Database.Seeds;

public class ScoreSeed : IEntityTypeConfiguration<Score>
{
    public void Configure(EntityTypeBuilder<Score> builder)
    {
        builder.HasData(
            new Score
            {
                ID = Guid.Parse("aaaaaaa0-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                CourseSessionID = Guid.Parse("44444444-4444-4444-4444-444444444444"), // Matematicas Session
                StudentID = Guid.Parse("00000000-0000-0000-0000-000000000001"), // Maria Gonzalez
                Value = 10,
                IsApproved = true
            },
            new Score
            {
                ID = Guid.Parse("bbbbbbb0-bbbb-bbbb-bbbb-bbbbbbbbbbbb"),
                CourseSessionID = Guid.Parse("55555555-5555-5555-5555-555555555555"), // Historia Session
                StudentID = Guid.Parse("00000000-0000-0000-0000-000000000002"), // Juan Perez
                Value = 8,
                IsApproved = true
            },
            new Score
            {
                ID = Guid.Parse("ccccccc0-cccc-cccc-cccc-cccccccccccc"),
                CourseSessionID = Guid.Parse("66666666-6666-6666-6666-666666666666"), // Ciencias Session
                StudentID = Guid.Parse("00000000-0000-0000-0000-000000000003"), // Carlos Rodriguez
                Value = 5,
                IsApproved = false
            }
        );

    }
}
