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
                CourseSessionStudentID = Guid.Parse("77777777-7777-7777-7777-777777777777"), // Maria Gonzalez
                Value = 10,
                IsApproved = true
            },
            new Score
            {
                ID = Guid.Parse("bbbbbbb0-bbbb-bbbb-bbbb-bbbbbbbbbbbb"),
                CourseSessionStudentID = Guid.Parse("88888888-8888-8888-8888-888888888888"), // Juan Perez
                Value = 8,
                IsApproved = true
            },
            new Score
            {
                ID = Guid.Parse("ccccccc0-cccc-cccc-cccc-cccccccccccc"),
                CourseSessionStudentID = Guid.Parse("99999999-9999-9999-9999-999999999999"), // Carlos Rodriguez
                Value = 5,
                IsApproved = false
            }
        );

    }
}
