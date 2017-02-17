using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Entities.HumanResources;

namespace MyFirstCoreWeb.Models.DepartmentViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<Department> Departments { get; set; }
    }
}
