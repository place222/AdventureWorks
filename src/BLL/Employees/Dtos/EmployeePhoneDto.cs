using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Employees.Dtos
{
    public class EmployeePhoneDto
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public int PhoneNumberType { get; set; }
    }
}
