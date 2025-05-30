using WebApi.Entities;
using WebApi.Models;

namespace WebApi.Factories;

public static class ProfileFactory
{
    public static ProfileEntity Create(CreateProfileModel model)
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
}
