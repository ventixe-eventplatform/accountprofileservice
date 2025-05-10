using System.ComponentModel.DataAnnotations;

namespace WebApi.Entities;

public class AddressTypeEntity
{
    [Key]
    public int AddressTypeId { get; set; }
    public string AddressType { get; set; } = null!;

}
