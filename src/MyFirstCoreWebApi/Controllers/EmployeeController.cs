using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using BLL.Employees;
using BLL.Employees.Dtos;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyFirstCoreWebApi.Models;

namespace MyFirstCoreWebApi.Controllers
{
    [EnableCors("AllowDomain")]
    [Route("api/[controller]")]
    public class EmployeeController : BaseController
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService, ILoggerFactory loggerFactory) : base(loggerFactory)
        {
            _employeeService = employeeService;
        }


        [Route("GetEmployeesByPage")]
        [HttpPost]
        public async Task<BasePageDto<EmployeeDto>> GetEmployeesByPage([FromForm]BasePageInput input)
        {
            try
            {
                return await _employeeService.GetEmployeesByPageAsync(input);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.GetBaseException().Message);
                throw;
            }
        }

        //todo::没有拿取位置数据
        [Route("GetEmployeeDetailById")]
        [HttpPost]
        public async Task<EmployeeDetailDto> GetEmployeeDetailById([FromQuery] int employeeId)
        {
            try
            {
                return await _employeeService.GetEmployeeDetailByIdAsync(employeeId);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.GetBaseException().Message);
                throw;
            }
        }
    }

}
