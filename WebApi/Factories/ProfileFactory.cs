using WebApi.Entities;
using WebApi.Models;

namespace WebApi.Factories;

public static class ProfileFactory
{
    public static ProfileEntity Create(CreateProfileModel model)
    {
        var profile = new ProfileEntity
        {
            UserId = model.UserId,
            FirstName = model.FirstName,
            LastName = model.LastName,
        };

        profile.AddressInfos = model.AddressInfoModels.Select(x => new AddressInfoEntity
        {
            UserId = model.UserId,
            Profile = profile,
            AddressTypeId = x.AddressTypeId,
            StreetName = x.StreetName,
            StreetNumber = x.StreetNumber,
            PostalCode = x.PostalCode,
            City = x.City,
            Country = x.Country
        }).ToList();

        profile.ContactInfos = model.ContactInfoModels.Select(x => new ContactInfoEntity
        {
            UserId = model.UserId,
            Profile = profile,
            ContactTypeId = x.ContactTypeId,
            Value = x.Value
        }).ToList();

        return profile;
    }

    public static ProfileEntity Update(UpdateProfileModel model)
    {
        return new ProfileEntity
        {
            UserId = model.UserId,
            FirstName = model.FirstName,
            LastName = model.LastName,
            AddressInfos = model.AddressInfoModels.Select(x => new AddressInfoEntity
            {
                UserId = model.UserId,
                AddressTypeId = x.AddressTypeId,
                StreetName = x.StreetName,
                StreetNumber = x.StreetNumber,
                PostalCode = x.PostalCode,
                City = x.City,
                Country = x.Country
            }).ToList(),
            ContactInfos = model.ContactInfoModels.Select(x => new ContactInfoEntity
            {
                UserId = model.UserId,
                ContactTypeId = x.ContactTypeId,
                Value = x.Value
            }).ToList()
        };
    }

    public static ProfileModel Create(ProfileEntity entity)
    {
        return new ProfileModel
        {
            UserId = entity.UserId,
            FirstName = entity.FirstName,
            LastName = entity.LastName,
            AddressInfos = entity.AddressInfos.Select(x => new AddressInfoModel
            {
                AddressTypeId = x.AddressTypeId,
                StreetName = x.StreetName,
                StreetNumber = x.StreetNumber,
                PostalCode = x.PostalCode,
                City = x.City,
                Country = x.Country
            }).ToList()
        };
    }
}
