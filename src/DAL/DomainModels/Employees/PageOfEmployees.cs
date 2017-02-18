using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Entities.HumanResources;

namespace DAL.DomainModels.Employees
{
    public class PageOfEmployees 
    {
        public int TotalRecord { get; set; }
        public IEnumerable<PageOfEmployee> Employees { get; set; }
    }
}
