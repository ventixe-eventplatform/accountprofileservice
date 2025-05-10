using System.ComponentModel.DataAnnotations;

namespace WebApi.Entities;

public class ContactTypeEntity
{
    [Key]
    public int ContactTypeId { get; set; }
    public string ContactType { get; set; } = null!;

}
