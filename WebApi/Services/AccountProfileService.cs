using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
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
                await _profileRepository.SaveAsync();
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

    public async Task<ProfileModel?> GetProfileAsync(string userId)
    {
        try
        {
            var entity = await _profileRepository.GetAsync(x => x.UserId == userId, query => query.Include(x => x.AddressInfos.Where(x => x.AddressTypeId == 1)));
            if (entity == null)
            {
                Debug.WriteLine($"No profile found for userId: {userId}");
                return null!;
            }
            return ProfileFactory.Create(entity);
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error fetching profile information: {ex.Message}");
            return null!;
        }
    }

    public async Task<AccountProfileServiceResult> UpdateAsync(UpdateProfileModel model)
    {
        var existingEntity = await _profileRepository.GetAsync(x => x.UserId == model.UserId, query => query.Include(x => x.AddressInfos).Include(x => x.ContactInfos));
        if (existingEntity == null)
            return new AccountProfileServiceResult { Success = false, Error = "Profile does not exist." };

        try
        {
            var updatedEntity = ProfileFactory.Update(model, existingEntity);
            await _profileRepository.UpdateProfileEntityAsync(existingEntity, updatedEntity);
            return new AccountProfileServiceResult { Success = true };
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"{ex.Message}");
            return new AccountProfileServiceResult { Success = false, Error = "Error updating profile information." };
        }
    }

    public async Task<AccountProfileServiceResult> UserExistsAsync(UserIdRequest request)
    {
        var exists = await _profileRepository.AlreadyExistsAsync(x => x.UserId == request.Id);

        return new AccountProfileServiceResult
        {
            Success = true,
            Data = exists
        };
    }
}
