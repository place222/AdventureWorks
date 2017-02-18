using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.DomainModels;
using DAL.DomainModels.Employees;
using DAL.Entities.HumanResources;
using DAL.Identity;

namespace DAL.Repositories
{
    public interface IEmployeeRepository
    {
        Task<bool> IsUserIsEmployee(User user);

        Task<EmployeeDetail> GetEmployeeDetailById(int id);

        Task<PageOfEmployees> GetEmployeesByPageAsync(int start, int length);
    }
}
