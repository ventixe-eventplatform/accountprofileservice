using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.Data;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<ProfileEntity> Profiles { get; set; }
    public DbSet<AddressInfoEntity> AddressInfos { get; set; }
    public DbSet<AddressTypeEntity> AddressTypes { get; set; }
    public DbSet<ContactInfoEntity> ContactInfos { get; set; }
    public DbSet<ContactTypeEntity> ContactTypes { get; set; }
}
