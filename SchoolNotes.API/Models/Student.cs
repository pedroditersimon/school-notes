namespace SchoolNotes.API.Models;

public class Student : BaseModel<Guid>
{
    public string? FirstName { get; set; }   // Juan
    public string? LastName { get; set; }    // Perez
    public string? FullName { get; set; }    // Juan Paco Perez

    public virtual ICollection<Note> Notes { get; set; }
}
