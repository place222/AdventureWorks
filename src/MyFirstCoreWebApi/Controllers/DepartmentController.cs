using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using BLL.Departments;
using BLL.Departments.Dtos;
using Microsoft.AspNetCore.Mvc;
using BLL.Employees;
using BLL.Employees.Dtos;
using Microsoft.AspNetCore.Cors;
using Microsoft.Extensions.Logging;
using MyFirstCoreWebApi.Models;
using NuGet.Protocol.Core.v3;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MyFirstCoreWebApi.Controllers
{
    [EnableCors("AllowDomain")]
    [Route("api/[controller]")]
    public class DepartmentController : BaseController
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService, ILoggerFactory loggerFactory) : base(loggerFactory)
        {
            _departmentService = departmentService;
        }

        [Route("GetDepartmentsByPage")]
        [HttpPost]
        public async Task<BasePageDto<DepartmentDto>> GetDepartmentsByPage([FromForm]BasePageInput input)
        {
            try
            {
                return await _departmentService.GetDepartmentsByPageAsync(input);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.GetBaseException().Message);
                throw;
            }
        }

        [Route("GetDepartmentById")]
        [HttpGet]
        public async Task<DepartmentDto> GetDepartmentById([FromQuery]int departmentId)
        {
            try
            {
                return await _departmentService.GetDepartmentByIdAsync(departmentId);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.GetBaseException().Message);
                throw;
            }
        }

        [Route("DeleteDepartmentById")]
        [HttpGet]
        public async Task DeleteDepartmentById([FromQuery]int departmentId)
        {
            try
            {
                await _departmentService.DeleteDepartmentByIdAsync(departmentId);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.GetBaseException().Message);
                throw;
            }
        }
        [Route("AddDepartment")]
        [HttpPost]
        public async Task<object> AddDepartment([FromForm] DepartmentDto input)
        {
            try
            {
                //<BaseResponse<IEnumerable<DepartmentDto>>>
                //简易测试一下Editor能不能自动刷新 需要是一个数组结构可以进行自动刷新 看看文档看看怎么改
                await _departmentService.AddDepartmentAsync(input);
                return new { data=123};
                //return new BaseResponse<IEnumerable<DepartmentDto>>()
                //{
                //    Data = new DepartmentDto[]
                //    {
                //        new DepartmentDto
                //        {
                //            DepartmentID = 100,
                //            GroupName = "测试server",
                //            Name = "测试server",
                //            ModifiedDate = DateTime.Now
                //        }
                //    }
                //};
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.GetBaseException().Message);
                throw;
            }
        }

        [Route("UpdateDepartment")]
        [HttpPost]
        public async Task UpdateDepartment([FromForm] DepartmentDto input)
        {
            try
            {
                await _departmentService.UpdateDepartmentAsync(input);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.GetBaseException().Message);
                throw;
            }
        }
        [Route("GetGroups")]
        [HttpPost]
        public async Task<IEnumerable<GroupDto>> GetGroupsAsync()
        {
            try
            {
                return await _departmentService.GetGroupsAsync();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.GetBaseException().Message);
                throw;
            }
        }
    }
}
