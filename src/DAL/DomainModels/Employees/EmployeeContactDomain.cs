using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.DomainModels.Employees
{
    public class EmployeeContactDomain
    {
        public int BusinessEntityID { get; set; }
        public int ContactTypeID { get; set; }
        public int PersonID { get; set; }
        public string Name { get; set; }
    }
}
