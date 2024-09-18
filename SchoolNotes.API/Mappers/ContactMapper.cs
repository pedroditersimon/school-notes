using SchoolNotes.API.Models;
using SchoolNotes.API.Models.DTOs;

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
