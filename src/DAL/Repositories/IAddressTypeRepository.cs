using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Entities.Person;

namespace DAL.Repositories
{
    public interface IAddressTypeRepository
    {
        Task<IEnumerable<AddressType>> GetAddressTypeAsync();
        Task AddAddressTypeAsync(AddressType entity);
        Task UpdateAddressTypeAsync(AddressType entity);
        Task DeleteAddressTypeAsync(AddressType entity);
    }
}
