namespace SchoolNotes.API.Models;

public class CourseSessionStudents
{
    public Guid CourseSessionID { get; set; }
    public CourseSession CourseSession { get; set; }

    public Guid StudentID { get; set; }
    public Student Student { get; set; }

    public virtual ICollection<Score> Scores { get; set; }
}
