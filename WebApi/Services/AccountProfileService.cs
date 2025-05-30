using System.Diagnostics;
using WebApi.Factories;
using WebApi.Models;
using WebApi.Repositories.Interfaces;

namespace WebApi.Services;

public class AccountProfileService(IProfileRepository profileRepository) : IAccountProfileService
{
    private readonly IProfileRepository _profileRepository = profileRepository;

    public async Task<AccountProfileServiceResult> CreateAsync(CreateProfileModel model)
    {
        try
        {
            bool exists = await _profileRepository.AlreadyExistsAsync(x => x.UserId == model.UserId);

            if (!exists)
            {
                var entity = ProfileFactory.Create(model);
                var result = await _profileRepository.AddEntityAsync(entity);
                if (!result)
                    return new AccountProfileServiceResult { Success = false, Error = "Failed to save profile information." };

                return new AccountProfileServiceResult { Success = true, Message = "Profile information saved successfully." };
            }

            return new AccountProfileServiceResult { Success = false, Error = "User already exists." };
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Unexpected error occured while saving the profile information: {ex.Message}");
            return new AccountProfileServiceResult { Success = false, Error = "An unexpected error occured." };
        }
    }
}
