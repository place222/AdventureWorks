using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.DomainModels;
using DAL.Entities.HumanResources;

namespace DAL.Repositories
{
    public interface IDepartmentRepository
    {
        Task<PageDomain<Department>> GetDepartmentsByPageAsync(int start, int length);
    }
}
