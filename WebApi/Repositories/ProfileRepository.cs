using WebApi.Data;
using WebApi.Entities;
using WebApi.Repositories.Interfaces;

namespace WebApi.Repositories;

public class ProfileRepository : BaseRepository<ProfileEntity>, IProfileRepository
{
    public ProfileRepository(DataContext context) : base(context)
    {
    }
}
