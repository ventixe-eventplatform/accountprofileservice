namespace WebApi.Models;

public class ProfileModel
{
    public string UserId { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public IEnumerable<AddressInfoModel> AddressInfos { get; set; } = new List<AddressInfoModel>();
}
