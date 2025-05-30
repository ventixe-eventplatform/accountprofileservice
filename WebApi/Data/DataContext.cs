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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AddressTypeEntity>().HasData(
            new AddressTypeEntity { AddressTypeId = 1, AddressType = "Delivery Address" },
            new AddressTypeEntity { AddressTypeId = 2, AddressType = "Billing Address" }
        );

        modelBuilder.Entity<ContactTypeEntity>().HasData(
            new ContactTypeEntity { ContactTypeId = 1, ContactType = "Email" },
            new ContactTypeEntity { ContactTypeId = 2, ContactType = "Phone" }
        );
    }
}
