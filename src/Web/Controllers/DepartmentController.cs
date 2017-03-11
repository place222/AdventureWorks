using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.DomainModels;
using DAL.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Web.Models.DepartmentViewModels;

namespace Web.Controllers
{
    public class DepartmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}