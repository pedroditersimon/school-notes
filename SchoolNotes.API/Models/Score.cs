using System.ComponentModel.DataAnnotations;

namespace SchoolNotes.API.Models;

public class Score : BaseModel<Guid>
{
    [Range(1, 10)]
    public int Value { get; set; }
    public bool IsApproved { get; set; }


    // relations
    public Guid CourseSessionID { get; set; }
    public Guid StudentID { get; set; }
    public CourseSessionStudents CourseSessionStudent { get; set; }
}
