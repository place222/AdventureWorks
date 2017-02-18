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
        public async Task<BaseOutput<BasePageDto<DepartmentDto>>> GetDepartmentsByPage([FromForm]BasePageInput input)
        {
            var result = new BaseOutput<BasePageDto<DepartmentDto>>();

            try
            {
                result.Data = await _departmentService.GetDepartmentsByPageAsync(input);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message, ex.StackTrace);
                result.ErrorCode = 500;
                result.ErrorMessage = ex.GetBaseException().Message;
            }

            return result;
        }
    }
}
