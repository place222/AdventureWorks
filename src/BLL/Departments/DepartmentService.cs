using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Departments.Dtos;
using DAL.Repositories;

namespace BLL.Departments
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public Task<GetGroupOutput> GetGroups(GetGroupInput input)
        {
            throw new NotImplementedException();
        }
    }
}
