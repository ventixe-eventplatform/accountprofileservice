using System.ComponentModel.DataAnnotations;

namespace WebApi.Models;

public class UpdateProfileModel
{
    public string UserId { get; set; } = null!;

    [Required]
    [StringLength(50)]
    public string FirstName { get; set; } = null!;

    [Required]
    [StringLength(50)]
    public string LastName { get; set; } = null!;
    public IEnumerable<UpdateAddressInfoModel> AddressInfoModels { get; set; } = new List<UpdateAddressInfoModel>();
    public IEnumerable<UpdateContactInfoModel> ContactInfoModels { get; set; } = new List<UpdateContactInfoModel>();
}
