namespace SchoolNotes.API.Models;

public class Note : BaseModel<Guid>
{
    public Student Student { get; set; }
    public Course Subject { get; set; }

    public int Score { get; set; }
    public bool IsApproved { get; set; }
}
