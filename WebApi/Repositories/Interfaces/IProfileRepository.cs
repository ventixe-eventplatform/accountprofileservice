using WebApi.Entities;

namespace WebApi.Repositories.Interfaces;

public interface IProfileRepository : IBaseRepository<ProfileEntity>
{
    Task<ProfileEntity> UpdateProfileEntityAsync(ProfileEntity existingEntity, ProfileEntity updatedEntity);
}
