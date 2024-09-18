using SchoolNotes.API.DTOs.Contact;
using SchoolNotes.API.Models;

namespace SchoolNotes.API.Mappers;

public static class ContactMappers
{

    // Contact -> ContactResult
    public static ContactResult ToResult(this Contact contact)
    {
        return new()
        {
            ID = contact.ID,
            FirstName = contact.FirstName,
            LastName = contact.LastName,
            DNI = contact.DNI
        };
    }

    // ContactResult -> Contact
    public static Contact FromResult(this ContactResult result)
    {
        return new()
        {
            ID = result.ID,
            DNI = result.DNI,
            FirstName = result.FirstName,
            LastName = result.LastName
        };
    }

    // UpdateContactRequest -> Contact
    public static Contact ToContact(this UpdateContactRequest request)
    {
        return new()
        {
            ID = request.ID,
            DNI = request.DNI,
            FirstName = request.FirstName,
            LastName = request.LastName
        };
    }


    // CreateContactRequest -> Contact
    public static Contact ToContact(this CreateContactRequest request)
    {
        return new()
        {
            DNI = request.DNI,
            FirstName = request.FirstName,
            LastName = request.LastName,
        };
    }

}
