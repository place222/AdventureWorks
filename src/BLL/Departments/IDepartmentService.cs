using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Departments.Dtos;

namespace BLL.Departments
{
    public interface IDepartmentService
    {
        Task<GetGroupOutput> GetGroups(GetGroupInput input);
    }
}
