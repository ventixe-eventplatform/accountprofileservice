using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities;

public class AddressInfoEntity
{
    [Key]
    [Column(TypeName = "varchar(36)")]
    public string AddressId { get; set; } = Guid.NewGuid().ToString();


    [Column(TypeName = "varchar(36)")]
    [ForeignKey(nameof(Profile))]
    public string UserId { get; set; } = null!;
    public ProfileEntity Profile { get; set; } = null!;


    [ForeignKey(nameof(AddressType))]
    public int AddressTypeId { get; set; }
    public AddressTypeEntity AddressType { get; set; } = null!;


    [Column(TypeName = "nvarchar(50)")]
    public string StreetName { get; set; } = null!;

    [Column(TypeName = "nvarchar(10)")]
    public string? StreetNumber  { get; set; }

    [Column(TypeName = "nvarchar(10)")]
    public string PostalCode { get; set; } = null!;

    [Column(TypeName = "nvarchar(50)")]
    public string City { get; set; } = null!;

    [Column(TypeName = "nvarchar(50)")]
    public string Country { get; set; } = null!;
}
