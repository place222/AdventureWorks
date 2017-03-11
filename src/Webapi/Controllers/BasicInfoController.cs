using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Basic;
using BLL.Basic.Dtos;
using DAL.Entities.Person;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyFirstCoreWebApi.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MyFirstCoreWebApi.Controllers
{
    [Route("api/[controller]")]
    public class BasicInfoController : BaseController
    {
        private readonly IBasicInfoService _basicInfoService;
        public BasicInfoController(ILoggerFactory loggerFactory, IBasicInfoService basicInfoService) : base(loggerFactory)
        {
            _basicInfoService = basicInfoService;
        }

        /// <summary>
        /// 获取电话类型
        /// </summary>
        /// <returns></returns>
        [Route("GetPhoneNumberType")]
        [HttpPost]
        public async Task<BaseOutput<IEnumerable<PhoneNumberTypeDto>>> GetPhoneNumberType()
        {
            var output = new BaseOutput<IEnumerable<PhoneNumberTypeDto>>();

            output.Data = await _basicInfoService.GetPhoneNumberTypeAsync();

            return output;
        }

        /// <summary>
        /// 增加电话类型
        /// </summary>
        /// <param name="phoneNumberType"></param>
        /// <returns></returns>
        [Route("AddPhoneNumberType")]
        [HttpPost]
        public async Task<BaseOutput> AddPhoneNumberType([FromBody]PhoneNumberTypeDto phoneNumberType)
        {
            await _basicInfoService.AddPhoneNumberTypeAsync(phoneNumberType);

            return new BaseOutput();
        }

        /// <summary>
        /// 修改电话类型
        /// </summary>
        /// <param name="phoneNumberType"></param>
        /// <returns></returns>
        [Route("UpdatePhoneNumberType")]
        [HttpPost]
        public async Task<BaseOutput> UpdatePhoneNumberType([FromBody]PhoneNumberTypeDto phoneNumberType)
        {
            await _basicInfoService.UpdatePhoneNumberTypeAsync(phoneNumberType);

            return new BaseOutput();
        }

        /// <summary>
        /// 删除电话类型
        /// </summary>
        /// <param name="phoneNumberType"></param>
        /// <returns></returns>
        [Route("DeletePhoneNumberType")]
        [HttpPost]
        public async Task<BaseOutput> DeletePhoneNumberType([FromBody]PhoneNumberTypeDto phoneNumberType)
        {
            await _basicInfoService.DeletePhoneNumberTypeAsync(phoneNumberType);

            return new BaseOutput();
        }

        /// <summary>
        /// 获取联系类型
        /// </summary>
        /// <returns></returns>
        [Route("GetContactType")]
        [HttpPost]
        public async Task<BaseOutput<IEnumerable<ContactTypeDto>>> GetContactType()
        {
            var output = new BaseOutput<IEnumerable<ContactTypeDto>>();

            output.Data = await _basicInfoService.GetContactTypeAsync();

            return output;
        }

        /// <summary>
        /// 增加联系类型
        /// </summary>
        /// <param name="contactType"></param>
        /// <returns></returns>
        [Route("AddContactType")]
        [HttpPost]
        public async Task<BaseOutput> AddContactType([FromBody]ContactTypeDto contactType)
        {
            await _basicInfoService.AddContactTypeAsync(contactType);

            return new BaseOutput();
        }

        /// <summary>
        /// 修改类型类型
        /// </summary>
        /// <param name="contactType"></param>
        /// <returns></returns>
        [Route("UpdateContactType")]
        [HttpPost]
        public async Task<BaseOutput> UpdateContactType([FromBody]ContactTypeDto contactType)
        {
            await _basicInfoService.UpdateContactTypeAsync(contactType);

            return new BaseOutput();
        }

        /// <summary>
        /// 删除联系类型
        /// </summary>
        /// <param name="contactType"></param>
        /// <returns></returns>
        [Route("DeleteContactType")]
        [HttpPost]
        public async Task<BaseOutput> DeleteContactType([FromBody]ContactTypeDto contactType)
        {
            await _basicInfoService.DeleteContactTypeAsync(contactType);

            return new BaseOutput();
        }
        /// <summary>
        /// 获取地址类型
        /// </summary>
        /// <returns></returns>
        [Route("GetAddressType")]
        [HttpPost]
        public async Task<BaseOutput<IEnumerable<AddressTypeDto>>> GetAddressType()
        {
            var output = new BaseOutput<IEnumerable<AddressTypeDto>>();

            output.Data = await _basicInfoService.GetAddressTypeAsync();

            return output;
        }

        /// <summary>
        /// 增加地址类型
        /// </summary>
        /// <param name="addressType"></param>
        /// <returns></returns>
        [Route("AddAddressType")]
        [HttpPost]
        public async Task<BaseOutput> AddAddressType([FromBody]AddressTypeDto addressType)
        {
            await _basicInfoService.AddAddressTypeAsync(addressType);

            return new BaseOutput();
        }

        /// <summary>
        /// 修改地址类型
        /// </summary>
        /// <param name="addressType"></param>
        /// <returns></returns>
        [Route("UpdateAddressType")]
        [HttpPost]
        public async Task<BaseOutput> UpdateAddressType([FromBody]AddressTypeDto addressType)
        {
            await _basicInfoService.UpdateAddressTypeAsync(addressType);
            
            return new BaseOutput();
        }

        /// <summary>
        /// 删除地址类型
        /// </summary>
        /// <param name="addressType"></param>
        /// <returns></returns>
        [Route("DeleteAddressType")]
        [HttpPost]
        public async Task<BaseOutput> DeleteAddressType([FromBody]AddressTypeDto addressType)
        {
            await _basicInfoService.DeleteAddressTypeAsync(addressType);

            return new BaseOutput();
        }

    }
}
