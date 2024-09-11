using System.ComponentModel.DataAnnotations;

namespace SchoolNotes.API.Models;

public class Score : BaseModel<Guid>
{
    public Student Student { get; set; }
    public Course Subject { get; set; }

    [Range(1, 10)]
    public int Value { get; set; }
    public bool IsApproved { get; set; }
}
