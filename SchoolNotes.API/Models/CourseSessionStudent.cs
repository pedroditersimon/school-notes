namespace SchoolNotes.API.Models;

public class CourseSessionStudent : BaseModel<Guid>
{
    public Guid CourseSessionID { get; set; }
    public CourseSession? CourseSession { get; set; }

    public Guid StudentID { get; set; }
    public Student? Student { get; set; }
}
