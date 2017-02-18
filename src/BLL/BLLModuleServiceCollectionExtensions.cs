using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Employees.Dtos;
using DAL.DomainModels.Employees;
using Microsoft.Extensions.DependencyInjection;
using BLL.Departments;
using BLL.Employees;
using DAL;

namespace BLL
{
    public static class BLLModuleServiceCollectionExtensions
    {
        public static void AddBLLServices(this IServiceCollection services)
        {
            services.AddDALServices();

            services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddTransient<IDepartmentService, DepartmentService>();

            services.InitializeAutoMapper();
        }
        public static void InitializeAutoMapper(this IServiceCollection services)
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<PageOfEmployee, EmployeeDto>();
                config.CreateMap<PageOfEmployees, GetEmployeesByPageOutput>()
                    .ForMember(x => x.ITotalRecords, x => x.MapFrom(c => c.TotalRecord))
                    .ForMember(x => x.ITotalDisplayRecords, x => x.MapFrom(c => c.TotalRecord))
                    .ForMember(x => x.Data, x => x.MapFrom(c => c.Employees));
            });
        }
    }
}
