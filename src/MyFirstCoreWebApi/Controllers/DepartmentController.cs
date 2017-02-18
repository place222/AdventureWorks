using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BLL.Employees;
using BLL.Employees.Dtos;
using Microsoft.AspNetCore.Cors;
using NuGet.Protocol.Core.v3;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MyFirstCoreWebApi.Controllers
{
    [EnableCors("AllowDomain")]
    [Route("api/[controller]")]
    public class DepartmentController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public DepartmentController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [Route("GetEmployees")]
        [HttpPost]
        public async Task<GetEmployeesByPageOutput> GetEmployees([FromForm]GetEmployeesByPageInput input)
        {
            try
            {
                return await _employeeService.GetEmployeesByPageAsync(input);
            }
            catch (Exception ex)
            {
                return new GetEmployeesByPageOutput();
            }
        }
    }
}
