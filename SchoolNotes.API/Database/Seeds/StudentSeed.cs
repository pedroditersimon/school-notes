using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolNotes.API.Models;

namespace SchoolNotes.API.Database.Seeds;

public class StudentSeed : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.HasData(
            new Student
            {
                ID = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                FirstName = "Maria",
                LastName = "Gonzalez"
            },
            new Student
            {
                ID = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                FirstName = "Juan",
                LastName = "Perez"
            },
            new Student
            {
                ID = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                FirstName = "Carlos",
                LastName = "Rodriguez"
            }
        );

    }
}
