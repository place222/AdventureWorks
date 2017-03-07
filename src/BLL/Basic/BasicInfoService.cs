using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Basic.Dtos;
using Dapper;
using DAL.Entities.Person;
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


        public BasicInfoService(IPhoneNumberTypeRepository phoneNumberTypeRepository, IContactTypeRepository contactTypeRepository, IAddressTypeRepository addressTypeRepository)
        {
            _phoneNumberTypeRepository = phoneNumberTypeRepository;
            _contactTypeRepository = contactTypeRepository;
            _addressTypeRepository = addressTypeRepository;
        }

        /// <summary>
        /// 获得电话类型
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<PhoneNumberTypeDto>> GetPhoneNumberTypeAsync()
        {
            var list = await _phoneNumberTypeRepository.GetPhoneNumberTypeAsync();

            return Mapper.Map<IEnumerable<PhoneNumberTypeDto>>(list);
        }

        /// <summary>
        /// 增加电话类型
        /// </summary>
        /// <param name="phoneNumberType"></param>
        /// <returns></returns>
        public async Task AddPhoneNumberTypeAsync(PhoneNumberTypeDto phoneNumberType)
        {
            var entity = Mapper.Map<PhoneNumberType>(phoneNumberType);

            await _phoneNumberTypeRepository.AddPhoneNumberTypeAsync(entity);
        }

        /// <summary>
        /// 修改电话类型
        /// </summary>
        /// <param name="phoneNumberType"></param>
        /// <returns></returns>
        public async Task UpdatePhoneNumberTypeAsync(PhoneNumberTypeDto phoneNumberType)
        {
            var entity = Mapper.Map<PhoneNumberType>(phoneNumberType);

            await _phoneNumberTypeRepository.UpdatePhoneNumberTypeAsync(entity);
        }

        /// <summary>
        /// 删除电话类型
        /// </summary>
        /// <param name="phoneNumberType"></param>
        /// <returns></returns>
        public async Task DeletePhoneNumberTypeAsync(PhoneNumberTypeDto phoneNumberType)
        {
            var entity = Mapper.Map<PhoneNumberType>(phoneNumberType);

            await _phoneNumberTypeRepository.DeletePhoneNumberTypeAsync(entity);
        }

        /// <summary>
        /// 获取联系类型列表
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ContactTypeDto>> GetContactTypeAsync()
        {
            var list = await _contactTypeRepository.GetContactTypeAsync();

            return Mapper.Map<IEnumerable<ContactTypeDto>>(list);
        }

        /// <summary>
        /// 增加联系类型
        /// </summary>
        /// <param name="contactType"></param>
        /// <returns></returns>
        public async Task AddContactTypeAsync(ContactTypeDto contactType)
        {
            var entity = Mapper.Map<ContactType>(contactType);

            await _contactTypeRepository.AddContactTypeAsync(entity);
        }

        /// <summary>
        /// 修改联系类型
        /// </summary>
        /// <param name="contactType"></param>
        /// <returns></returns>
        public async Task UpdateContactTypeAsync(ContactTypeDto contactType)
        {
            var entity = Mapper.Map<ContactType>(contactType);

            await _contactTypeRepository.UpdateContactTypeAsync(entity);
        }

        /// <summary>
        /// 删除联系类型
        /// </summary>
        /// <param name="contactType"></param>
        /// <returns></returns>
        public async Task DeleteContactTypeAsync(ContactTypeDto contactType)
        {
            var entity = Mapper.Map<ContactType>(contactType);

            await _contactTypeRepository.DeleteContactTypeAsync(entity);
        }

        /// <summary>
        /// 获取地址类型
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<AddressTypeDto>> GetAddressTypeAsync()
        {
            var list = await _addressTypeRepository.GetAddressTypeAsync();

            return Mapper.Map<IEnumerable<AddressTypeDto>>(list);
        }

        /// <summary>
        /// 增加地址类型
        /// </summary>
        /// <param name="addressType"></param>
        /// <returns></returns>
        public async Task AddAddressTypeAsync(AddressTypeDto addressType)
        {
            var entity = Mapper.Map<AddressType>(addressType);

            await _addressTypeRepository.AddAddressTypeAsync(entity);
        }

        /// <summary>
        /// 修改地址类型
        /// </summary>
        /// <param name="addressType"></param>
        /// <returns></returns>
        public async Task UpdateAddressTypeAsync(AddressTypeDto addressType)
        {
            var entity = Mapper.Map<AddressType>(addressType);

            await _addressTypeRepository.UpdateAddressTypeAsync(entity);
        }

        /// <summary>
        /// 删除地址类型
        /// </summary>
        /// <param name="addressType"></param>
        /// <returns></returns>
        public async Task DeleteAddressTypeAsync(AddressTypeDto addressType)
        {
            var entity = Mapper.Map<AddressType>(addressType);

            await _addressTypeRepository.DeleteAddressTypeAsync(entity);
        }
    }
}
