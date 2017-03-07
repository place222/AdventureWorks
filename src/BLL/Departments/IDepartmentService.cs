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
        Task<IEnumerable<GroupDto>> GetGroupsAsync();
        Task<BasePageDto<DepartmentDto>> GetDepartmentsByPageAsync(BasePageInput input);
        Task<DepartmentDto> GetDepartmentByIdAsync(int departmentId);
        Task DeleteDepartmentByIdAsync(int departmentId);
        Task AddDepartmentAsync(DepartmentDto input);
        Task UpdateDepartmentAsync(DepartmentDto input);
    }
}
