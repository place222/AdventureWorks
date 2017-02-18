using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Employees.Dtos
{
    public class GetEmployeesByPageInput
    {
        public int Start { get; set; }
        public int Length { get; set; }
    }
}
