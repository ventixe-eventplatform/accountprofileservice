using WebApi.Models;

namespace WebApi.Services;

public interface IAccountProfileService
{
    Task<AccountProfileServiceResult> CreateAsync(CreateProfileModel model);
}
