using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolNotes.API.Models;

namespace SchoolNotes.API.Database.Seeds;

public class TeacherSeed : IEntityTypeConfiguration<Teacher>
{
    public void Configure(EntityTypeBuilder<Teacher> builder)
    {
        builder.HasData(
            new Teacher
            {
                ID = Guid.Parse("00000000-0000-0000-0000-000000000001") // Maria
            }
        );
    }
}
