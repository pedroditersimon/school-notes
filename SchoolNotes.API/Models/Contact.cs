namespace SchoolNotes.API.Models;

public class Contact : BaseModel<Guid>
{
    public string? FirstName { get; set; }   // Juan
    public string? LastName { get; set; }    // Perez

    public string? DNI { get; set; }
}

