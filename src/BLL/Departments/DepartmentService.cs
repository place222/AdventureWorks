using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Departments.Dtos;
using BLL.Employees.Dtos;
using DAL.Entities.HumanResources;
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

        public async Task<IEnumerable<GroupDto>> GetGroupsAsync()
        {
            var result = await _departmentRepository.GetGroupsAsync();

            return Mapper.Map<IEnumerable<GroupDto>>(result);
        }

        public async Task<BasePageDto<DepartmentDto>> GetDepartmentsByPageAsync(BasePageInput input)
        {
            var result = await _departmentRepository.GetDepartmentsByPageAsync(input.Start, input.Length, input.Search);

            return Mapper.Map<BasePageDto<DepartmentDto>>(result);
        }

        public async Task<DepartmentDto> GetDepartmentByIdAsync(int departmentId)
        {
            var result = await _departmentRepository.GetDepartmentByIdAsync(departmentId);

            return Mapper.Map<DepartmentDto>(result);
        }

        public async Task DeleteDepartmentByIdAsync(int departmentId)
        {
            await _departmentRepository.DeleteDepartmentByIdAsync(departmentId);
        }

        public async Task<DepartmentDto> AddDepartmentAsync(DepartmentDto input)
        {
            var model = await _departmentRepository.AddDepartmentAsync(Mapper.Map<Department>(input));
            return Mapper.Map<DepartmentDto>(model);
        }

        public async Task UpdateDepartmentAsync(DepartmentDto input)
        {
            await _departmentRepository.UpdateDepartmentAsync(Mapper.Map<Department>(input));
        }
    }
}
