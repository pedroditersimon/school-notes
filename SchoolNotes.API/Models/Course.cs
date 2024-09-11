namespace SchoolNotes.API.Models;

public class Course : BaseModel<Guid>
{
    public string? Name { get; set; }


    // relations
    public virtual ICollection<CourseSession> CourseSessions { get; set; }
}
