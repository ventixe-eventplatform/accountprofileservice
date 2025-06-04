using System.ComponentModel.DataAnnotations;

namespace WebApi.Models;

public class UpdateAddressInfoModel
{
    public int AddressTypeId { get; set; }

    [Required]
    [StringLength(50)]
    public string StreetName { get; set; } = null!;

    [Required]
    [StringLength(10)]
    public string? StreetNumber { get; set; }

    [Required]
    [StringLength(10)]
    public string PostalCode { get; set; } = null!;

    [Required]
    [StringLength(50)]
    public string City { get; set; } = null!;

    [Required]
    [StringLength(50)]
    public string Country { get; set; } = null!;
}
