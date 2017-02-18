using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Employees.Dtos
{
    public class GetEmployeesByPageOutput
    {
        public int ITotalRecords { get; set; }
        public int ITotalDisplayRecords { get; set; }
        public IEnumerable<EmployeeDto> Data { get; set; }
    }
}
