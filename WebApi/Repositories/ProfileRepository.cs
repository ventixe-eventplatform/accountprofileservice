using System.Diagnostics;
using WebApi.Data;
using WebApi.Entities;
using WebApi.Repositories.Interfaces;

namespace WebApi.Repositories;

public class ProfileRepository : BaseRepository<ProfileEntity>, IProfileRepository
{
    public ProfileRepository(DataContext context) : base(context)
    {
    }

    public async Task<ProfileEntity> UpdateProfileEntityAsync(ProfileEntity existingEntity, ProfileEntity updatedEntity)
    {
        if (updatedEntity == null)
            throw new ArgumentNullException();

        try
        {
            _context.Entry(existingEntity).CurrentValues.SetValues(updatedEntity);

            _context.AddressInfos.RemoveRange(existingEntity.AddressInfos);
            _context.ContactInfos.RemoveRange(existingEntity.ContactInfos);

            existingEntity.AddressInfos = updatedEntity.AddressInfos;
            existingEntity.ContactInfos = updatedEntity.ContactInfos;

            await _context.SaveChangesAsync();
            return existingEntity;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error updating entity: {ex.Message}");
            throw;
        }
    }
}
