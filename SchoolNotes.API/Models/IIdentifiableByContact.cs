namespace SchoolNotes.API.Models;

public interface IIdentifiableByContact
{
    public Guid ContactID { get; } // point to the ID
    public Contact? Contact { get; set; } // ef navigation
}
