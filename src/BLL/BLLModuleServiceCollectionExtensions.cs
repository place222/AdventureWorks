using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Employees.Dtos;
using DAL.DomainModels.Employees;
using Microsoft.Extensions.DependencyInjection;
using BLL.Departments;
using BLL.Departments.Dtos;
using BLL.Employees;
using BLL.Products;
using BLL.Products.Dtos;
using DAL;
using DAL.DomainModels;
using DAL.DomainModels.Departments;
using DAL.Entities.HumanResources;
using DAL.Entities.Person;
using DAL.Entities.Production;

namespace BLL
{
    public static class BLLModuleServiceCollectionExtensions
    {
        public static void AddBLLServices(this IServiceCollection services)
        {
            services.AddDALServices();

            services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddTransient<IDepartmentService, DepartmentService>();
            services.AddTransient<IProductService, ProductService>();

            services.InitializeAutoMapper();
        }
        public static void InitializeAutoMapper(this IServiceCollection services)
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<EmployeeDomain, EmployeeDto>();
                config.CreateMap<Department, DepartmentDto>();
                config.CreateMap<GroupDomain, GroupDto>();
                config.CreateMap<EmployeeDetailDomain, EmployeeDetailDto>();
                config.CreateMap<EmailAddresses, EmailAddressesDto>();
                config.CreateMap<EmployeeAddressDomain, EmployeeAddressDto>();
                config.CreateMap<EmployeeInfoDomain, EmployeeInfoDto>();
                config.CreateMap<EmployeeContactDomain, EmployeeContactDto>();
                config.CreateMap<EmployeePhoneDomain, EmployeePhoneDto>();
                config.CreateMap<ProductModel, ProductModelDto>();
                //.ForMember(x => x.CatalogDescription, x => x.MapFrom(c => c.CatalogDescription.Value))
                //.ForMember(x => x.Instructions, x => x.MapFrom(c => c.Instructions.Value));

                config.CreateMap<PageDomain<EmployeeDomain>, BasePageDto<EmployeeDto>>()
                    .ForMember(x => x.ITotalRecords, x => x.MapFrom(c => c.TotalRecord))
                    .ForMember(x => x.ITotalDisplayRecords, x => x.MapFrom(c => c.TotalRecord));

                config.CreateMap<PageDomain<Department>, BasePageDto<DepartmentDto>>()
                    .ForMember(x => x.ITotalRecords, x => x.MapFrom(c => c.TotalRecord))
                    .ForMember(x => x.ITotalDisplayRecords, x => x.MapFrom(c => c.TotalRecord));

                config.CreateMap<PageDomain<ProductModel>, BasePageDto<ProductModelDto>>()
                    .ForMember(x => x.ITotalRecords, x => x.MapFrom(c => c.TotalRecord))
                    .ForMember(x => x.ITotalDisplayRecords, x => x.MapFrom(c => c.TotalRecord));
            });
        }
    }
}
