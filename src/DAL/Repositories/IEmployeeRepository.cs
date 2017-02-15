using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.DomainModels;
using DAL.Identity;

namespace DAL.Repositories
{
    public interface IEmployeeRepository
    {
        Task<bool> IsUserIsEmployee(User user);

        Task<EmployeeDetail> GetEmployeeDetailById(int id);


    }
}
