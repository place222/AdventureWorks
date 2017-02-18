using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.DomainModels;
using DAL.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyFirstCoreWeb.Models.DepartmentViewModels;
using NuGet.Protocol.Core.v3;

namespace MyFirstCoreWeb.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository _departmentRepository;
        private ILogger<DepartmentController> _logger;

        public DepartmentController(IDepartmentRepository departmentRepository, ILoggerFactory loggerFactory)
        {
            _departmentRepository = departmentRepository;
            _logger = loggerFactory.CreateLogger<DepartmentController>();
        }

        public IActionResult Index()
        {
            return View();

        }
        


    }
}