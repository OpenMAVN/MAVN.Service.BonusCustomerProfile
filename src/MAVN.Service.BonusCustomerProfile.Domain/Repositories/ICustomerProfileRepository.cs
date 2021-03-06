using MAVN.Service.BonusCustomerProfile.Domain.Models.CustomerProfile;
using System;
using System.Threading.Tasks;

namespace MAVN.Service.BonusCustomerProfile.Domain.Repositories
{
    public interface ICustomerProfileRepository
    {
        Task<CustomerProfileModel> GetCustomerProfileAsync(Guid customerId);

        Task<bool> InsertAsync(CustomerProfileModel customerProfile);

        Task UpdateAsync(CustomerProfileModel customerProfile);

        Task CreateOrUpdateAsync(CustomerProfileModel customerProfile);
    }
}
