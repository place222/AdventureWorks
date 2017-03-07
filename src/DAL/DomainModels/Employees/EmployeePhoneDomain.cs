using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.DomainModels.Employees
{
    public class EmployeePhoneDomain
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public int PhoneNumberType { get; set; }
    }
}
