using SchoolNotes.API.DTOs.Contact;
using SchoolNotes.API.Models;

namespace SchoolNotes.API.Mappers;

public static class ContactMapper
{
    public static ContactDTO ToDTO(this Contact contact)
    {
        return new()
        {
            FirstName = contact.FirstName,
            LastName = contact.LastName,
            DNI = contact.DNI
        };
    }
}
