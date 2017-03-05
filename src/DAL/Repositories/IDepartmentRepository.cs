using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.DomainModels;
using DAL.DomainModels.Departments;
using DAL.Entities.HumanResources;

namespace DAL.Repositories
{
    public interface IDepartmentRepository
    {
        Task<PageDomain<Department>> GetDepartmentsByPageAsync(int start, int length,string search);
        Task<IEnumerable<GroupDomain>> GetGroupsAsync();
        Task<Department> GetDepartmentByIdAsync(int departmentId);
        Task DeleteDepartmentByIdAsync(int departmentId);
        Task AddDepartmentAsync(Department department);
        Task UpdateDepartmentAsync(Department department);
    }
}
