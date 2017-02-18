using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.DomainModels;
using DAL.Repositories;
using Microsoft.AspNetCore.Mvc;
using MyFirstCoreWeb.Models.DepartmentViewModels;
using NuGet.Protocol.Core.v3;

namespace MyFirstCoreWeb.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["ModuleName"] = "部门管理";
            var vm = new IndexViewModel();
            vm.Departments = await
                _departmentRepository.GetDepartmentsByPage(new BasePageInput() { PageNumber = 1, PageSize = 10 });
            return View(vm);

        }
        //TODO::改成webapi
        [HttpPost]
        public async Task<IActionResult> Index(BasePageInput input)
        {
            var datas = await _departmentRepository.GetDepartmentsByPage(input);
            return Json(new { iTotalRecords = 16, iTotalDisplayRecords = 16, data = datas });
        }


    }
}