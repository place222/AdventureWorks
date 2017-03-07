using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Entities.Person;

namespace DAL.Repositories
{
    public interface IPhoneNumberTypeRepository
    {
        Task<IEnumerable<PhoneNumberType>> GetPhoneNumberTypeAsync();
        Task AddPhoneNumberTypeAsync(PhoneNumberType entity);
        Task UpdatePhoneNumberTypeAsync(PhoneNumberType entity);
        Task DeletePhoneNumberTypeAsync(PhoneNumberType entity);
    }
}
