using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Employees.Dtos
{
    public class EmployeeContactDto
    {
        public int BusinessEntityID { get; set; }
        public int ContactTypeID { get; set; }
        public int PersonID { get; set; }
        public string Name { get; set; }
    }
}
