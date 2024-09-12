namespace SchoolNotes.API.Models;

public class Student : BaseModel<Guid>
{
    public string? FirstName { get; set; }   // Juan
    public string? LastName { get; set; }    // Perez

}
