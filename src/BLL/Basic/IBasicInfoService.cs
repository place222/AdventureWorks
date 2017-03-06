using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Basic.Dtos;
using DAL.Entities.Person;

namespace BLL.Basic
{
    public interface IBasicInfoService
    {
        Task<IEnumerable<PhoneNumberTypeDto>> GetPhoneNumberTypeAsync();
        Task<IEnumerable<ContactTypeDto>> GetContactTypeAsync();
        Task<IEnumerable<AddressTypeDto>> GetAddressTypeAsync();
        Task AddPhoneNumberTypeAsync(PhoneNumberTypeDto phoneNumberType);
        Task UpdatePhoneNumberTypeAsync(PhoneNumberTypeDto phoneNumberType);
        Task DeletePhoneNumberTypeAsync(PhoneNumberTypeDto phoneNumberType);
        Task AddContactTypeAsync(ContactTypeDto contactType);
        Task UpdateContactTypeAsync(ContactTypeDto contactType);
        Task DeleteContactTypeAsync(ContactTypeDto contactType);
        Task AddAddressTypeAsync(AddressTypeDto addressType);
        Task UpdateAddressTypeAsync(AddressTypeDto addressType);
        Task DeleteAddressTypeAsync(AddressTypeDto addressType);
    }
}
