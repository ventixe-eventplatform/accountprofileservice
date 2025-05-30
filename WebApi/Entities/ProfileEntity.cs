using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities;

public class ProfileEntity
{
    [Key]
    [Column(TypeName = "varchar(36)")]
    public string UserId { get; set; } = null!;

    [Column(TypeName = "nvarchar(50)")]
    public string FirstName { get; set; } = null!;

    [Column(TypeName = "nvarchar(50)")]
    public string LastName { get; set; } = null!;

    public DateTime? CreatedDate { get; set; } = DateTime.Now;
    public ICollection<AddressInfoEntity> AddressInfos { get; set; } = new List<AddressInfoEntity>();
    public ICollection<ContactInfoEntity> ContactInfos { get; set; } = new List<ContactInfoEntity>();
}
