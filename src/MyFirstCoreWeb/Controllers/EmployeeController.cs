using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using DAL.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyFirstCoreWeb.Models.EmployeeViewModels;

namespace MyFirstCoreWeb.Controllers
{
    [Authorize(Roles = "Admin")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<IActionResult> Index(int id)
        {
            var model = await _employeeRepository.GetEmployeeDetailById(id);

            var vm = new EmployeeDetailViewModel();
            vm.BirthDate = model.BirthDate;
            vm.BusinessEntityID = model.BusinessEntityID;
            vm.JobTitle = model.JobTitle;
            vm.LoginID = model.LoginID;
            vm.MaritalStatus = model.MaritalStatus;
            vm.NationalIDNumber = model.NationalIDNumber;
            return View(vm);
        }
        [AllowAnonymous]
        public IActionResult Test()
        {
            return View();
        }
    }
}