using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities;

public class AddressTypeEntity
{
    [Key]
    public int AddressTypeId { get; set; }

    [Column(TypeName = "nvarchar(30)")]
    public string AddressType { get; set; } = null!;
}
