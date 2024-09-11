namespace SchoolNotes.API.Models;

public class CourseSession : BaseModel<Guid>
{

    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }


    // relations
    public Course Course { get; set; }
    public virtual ICollection<CourseSessionStudents> CourseSessionStudents { get; set; }
}
