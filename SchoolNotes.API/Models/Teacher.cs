using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolNotes.API.Models;

public class Teacher : BaseModel<Guid>, IIdentifiableByContact
{
    [ForeignKey(nameof(Contact))]
    public new Guid ID { get; set; }

    public Guid ContactID => ID;
    public Contact? Contact { get; set; }

}
