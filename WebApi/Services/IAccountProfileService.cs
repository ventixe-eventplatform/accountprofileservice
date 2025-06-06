using WebApi.Models;

namespace WebApi.Services;

public interface IAccountProfileService
{
    Task<AccountProfileServiceResult> CreateAsync(CreateProfileModel model);
    Task<ProfileModel?> GetProfileAsync(string userId);
    Task<AccountProfileServiceResult> UpdateAsync(UpdateProfileModel model);
    Task<AccountProfileServiceResult> UserExistsAsync(UserIdRequest request);
}
