using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Departments.Dtos;
using BLL.Employees.Dtos;

namespace BLL.Departments
{
    public interface IDepartmentService
    {
        Task<GetGroupOutput> GetGroups(GetGroupInput input);

        Task<BasePageDto<DepartmentDto>> GetDepartmentsByPageAsync(BasePageInput input);
    }
}
