using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Employees.Dtos;
using DAL.Repositories;

namespace BLL.Employees
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<GetEmployeesByPageOutput> GetEmployeesByPageAsync(GetEmployeesByPageInput input)
        {
            var result = await _employeeRepository.GetEmployeesByPageAsync(input.Start, input.Length);

            return Mapper.Map<GetEmployeesByPageOutput>(result);
        }
    }
}
