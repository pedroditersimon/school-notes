namespace SchoolNotes.API.Models;

public class CourseSession : BaseModel<Guid>
{
    public string? Name { get; set; }
    public string? Description { get; set; }

    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }


    // relations
    public Guid CourseID { get; set; }
    public Course? Course { get; set; }

    public Guid? TeacherID { get; set; }
    public Teacher? Teacher { get; set; }
}
