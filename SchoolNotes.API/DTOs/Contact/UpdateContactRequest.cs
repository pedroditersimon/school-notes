namespace SchoolNotes.API.DTOs.Contact;

public class UpdateContactRequest
{
    public Guid ID { get; set; }
    public string? FirstName { get; set; }   // Juan
    public string? LastName { get; set; }    // Perez

    public string? DNI { get; set; }
}
