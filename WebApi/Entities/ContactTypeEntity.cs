using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities;

public class ContactTypeEntity
{
    [Key]
    public int ContactTypeId { get; set; }

    [Column(TypeName = "nvarchar(30)")]
    public string ContactType { get; set; } = null!;
}
