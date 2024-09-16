using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolNotes.API.Models;

namespace SchoolNotes.API.Database.Seeds;

public class ContactSeed : IEntityTypeConfiguration<Contact>
{
    public void Configure(EntityTypeBuilder<Contact> builder)
    {
        builder.HasData(
            new Contact
            {
                ID = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                FirstName = "Maria",
                LastName = "Gonzalez",
                DNI = "00000001"
            },
            new Contact
            {
                ID = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                FirstName = "Juan",
                LastName = "Perez",
                DNI = "00000002"
            },
            new Contact
            {
                ID = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                FirstName = "Carlos",
                LastName = "Rodriguez",
                DNI = "00000003"
            }
        );
    }
}
