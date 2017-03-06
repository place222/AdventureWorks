using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Basic.Dtos;
using DAL.Repositories;
using Microsoft.Extensions.Options;
using MyFirstCoreWeb.Models;

namespace BLL.Basic
{
    public class BasicInfoService : IBasicInfoService
    {
        private readonly IPhoneNumberTypeRepository _phoneNumberTypeRepository;
        private readonly IContactTypeRepository _contactTypeRepository;
        private readonly IAddressTypeRepository _addressTypeRepository;

        public ConnectionOptions Options { get; }

        public BasicInfoService(IPhoneNumberTypeRepository phoneNumberTypeRepository, IContactTypeRepository contactTypeRepository, IAddressTypeRepository addressTypeRepository, IOptions<ConnectionOptions> options)
        {
            _phoneNumberTypeRepository = phoneNumberTypeRepository;
            _contactTypeRepository = contactTypeRepository;
            _addressTypeRepository = addressTypeRepository;
            Options = options.Value;
        }

        public Task<IEnumerable<PhoneNumberTypeDto>> GetPhoneNumberTypeAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ContactTypeDto>> GetContactTypeAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AddressTypeDto>> GetAddressTypeAsync()
        {
            throw new NotImplementedException();
        }

        public Task AddPhoneNumberTypeAsync(PhoneNumberTypeDto phoneNumberType)
        {
            throw new NotImplementedException();
        }

        public Task UpdatePhoneNumberTypeAsync(PhoneNumberTypeDto phoneNumberType)
        {
            throw new NotImplementedException();
        }

        public Task DeletePhoneNumberTypeAsync(PhoneNumberTypeDto phoneNumberType)
        {
            throw new NotImplementedException();
        }

        public Task AddContactTypeAsync(ContactTypeDto contactType)
        {
            throw new NotImplementedException();
        }

        public Task UpdateContactTypeAsync(ContactTypeDto contactType)
        {
            throw new NotImplementedException();
        }

        public Task DeleteContactTypeAsync(ContactTypeDto contactType)
        {
            throw new NotImplementedException();
        }

        public Task AddAddressTypeAsync(AddressTypeDto addressType)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAddressTypeAsync(AddressTypeDto addressType)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAddressTypeAsync(AddressTypeDto addressType)
        {
            throw new NotImplementedException();
        }
    }
}
