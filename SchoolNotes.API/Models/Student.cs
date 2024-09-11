namespace SchoolNotes.API.Models;

public class Student : BaseModel<Guid>
{
    public string? FirstName { get; set; }   // Juan
    public string? LastName { get; set; }    // Perez
    public string? FullName { get; set; }    // Juan Paco Perez

    // relations
    public virtual ICollection<CourseSessionStudents> CourseSessionStudents { get; set; }
}
