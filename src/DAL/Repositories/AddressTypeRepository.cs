using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Entities.Person;

namespace DAL.Repositories
{
    public class AddressTypeRepository : IAddressTypeRepository
    {
        public Task<IEnumerable<AddressType>> GetAddressTypeAsync()
        {
            throw new NotImplementedException();
        }

        public Task AddAddressTypeAsync(AddressType entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAddressTypeAsync(AddressType entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAddressTypeAsync(AddressType entity)
        {
            throw new NotImplementedException();
        }
    }
}
