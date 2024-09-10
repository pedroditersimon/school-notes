using System.ComponentModel.DataAnnotations;

namespace SchoolNotes.API.Models;

public class BaseModel<Tid>
{
    [Key]
    public Tid ID { get; set; }

    // soft delete
    public bool IsDeleted { get; set; }


    public DateTime CreatedDate { get; set; }
    public DateTime DeletedDate { get; set; }
    [ConcurrencyCheck]
    public DateTime UpdatedDate { get; set; }

}
