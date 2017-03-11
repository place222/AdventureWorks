using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Entities.Person;
using Microsoft.Extensions.Options;
using DAL.Models;

namespace DAL.Repositories
{
    public class PhoneNumberTypeRepository : IPhoneNumberTypeRepository
    {
        public ConnectionOptions Options { get; }
        public PhoneNumberTypeRepository(IOptions<ConnectionOptions> options)
        {
            this.Options = options.Value;
        }

        public Task<IEnumerable<PhoneNumberType>> GetPhoneNumberTypeAsync()
        {
            throw new NotImplementedException();
        }

        public Task AddPhoneNumberTypeAsync(PhoneNumberType entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdatePhoneNumberTypeAsync(PhoneNumberType entity)
        {
            throw new NotImplementedException();
        }

        public Task DeletePhoneNumberTypeAsync(PhoneNumberType entity)
        {
            throw new NotImplementedException();
        }
    }
}
