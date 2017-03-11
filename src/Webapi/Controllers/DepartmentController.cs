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
        public async Task<BaseOutput<BasePageDto<DepartmentDto>>> GetDepartmentsByPage([FromForm]BasePageInput input)
        {
            var result = new BaseOutput<BasePageDto<DepartmentDto>>();

            result.Data = await _departmentService.GetDepartmentsByPageAsync(input);

            return result;
        }

        [Route("GetDepartmentById")]
        [HttpPost]
        public async Task<BaseOutput<DepartmentDto>> GetDepartmentById([FromQuery]int departmentId)
        {
            var result = new BaseOutput<DepartmentDto>();

            result.Data = await _departmentService.GetDepartmentByIdAsync(departmentId);

            return result;
        }

        [Route("DeleteDepartmentById")]
        [HttpPost]
        public async Task<BaseOutput> DeleteDepartmentById([FromQuery]int departmentId)
        {
            await _departmentService.DeleteDepartmentByIdAsync(departmentId);

            return new BaseOutput();
        }
        [Route("AddDepartment")]
        [HttpPost]
        public async Task<BaseOutput> AddDepartment([FromForm] DepartmentDto input)
        {
            await _departmentService.AddDepartmentAsync(input);

            return new BaseOutput();
        }

        [Route("UpdateDepartment")]
        [HttpPost]
        public async Task<BaseOutput> UpdateDepartment([FromForm] DepartmentDto input)
        {
            await _departmentService.UpdateDepartmentAsync(input);

            return new BaseOutput();
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
