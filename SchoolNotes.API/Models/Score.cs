using System.ComponentModel.DataAnnotations;

namespace SchoolNotes.API.Models;

public class Score : BaseModel<Guid>
{
    [Range(1, 10)]
    public int Value { get; set; }
    public bool IsApproved { get; set; }


    // relations
    public Guid StudentID { get; set; }
    public Student? Student { get; set; }

    public Guid CourseSessionID { get; set; }
    public CourseSession? CourseSession { get; set; }
}
