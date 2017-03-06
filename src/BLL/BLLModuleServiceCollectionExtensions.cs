using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Basic;
using BLL.Basic.Dtos;
using BLL.Employees.Dtos;
using DAL.DomainModels.Employees;
using Microsoft.Extensions.DependencyInjection;
using BLL.Departments;
using BLL.Departments.Dtos;
using BLL.Employees;
using BLL.Products;
using BLL.Products.Dtos;
using BLL.Products.Dtos.Products;
using DAL;
using DAL.DomainModels;
using DAL.DomainModels.Departments;
using DAL.DomainModels.ProductModels;
using DAL.DomainModels.Products;
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
            services.AddTransient<IBasicInfoService, BasicInfoService>();

            services.InitializeAutoMapper();
        }
        public static void InitializeAutoMapper(this IServiceCollection services)
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<EmployeeDomain, EmployeeDto>().ReverseMap();
                config.CreateMap<Department, DepartmentDto>().ReverseMap();
                config.CreateMap<GroupDomain, GroupDto>().ReverseMap();
                config.CreateMap<EmployeeDetailDomain, EmployeeDetailDto>().ReverseMap();
                config.CreateMap<EmailAddresses, EmailAddressesDto>().ReverseMap();
                config.CreateMap<EmployeeAddressDomain, EmployeeAddressDto>().ReverseMap();
                config.CreateMap<EmployeeInfoDomain, EmployeeInfoDto>().ReverseMap();
                config.CreateMap<EmployeeContactDomain, EmployeeContactDto>().ReverseMap();
                config.CreateMap<EmployeePhoneDomain, EmployeePhoneDto>().ReverseMap();
                config.CreateMap<ProductModel, ProductModelDto>().ReverseMap();
                config.CreateMap<ProductDomain, ProductDto>().ReverseMap();

                config.CreateMap<ProductDetailDomain, ProductDetailDto>().ReverseMap();
                config.CreateMap<ProductInfoDomain, ProductInfoDto>().ReverseMap();
                config.CreateMap<ProductPhoto, ProductDetailPhotoDto>().ReverseMap();
                config.CreateMap<ProductCostHistory, ProductDetailCostHistoryDto>().ReverseMap();
                config.CreateMap<ProductReview, ProductReviewDto>().ReverseMap();
                config.CreateMap<ProductCostHistory, ProductDetailCostHistoryDto>().ReverseMap();
                config.CreateMap<ProductInventoryDomain, ProductInventoryDto>().ReverseMap();
                config.CreateMap<ProductListPriceHistory, ProductDetailListPriceHistoryDto>().ReverseMap();

                config.CreateMap<ProductModelDetailDoamin, ProductModelDetailDto>().ReverseMap();
                config.CreateMap<ProductDescription, ProductDescriptionDto>().ReverseMap();
                config.CreateMap<Illustration, IllustrationDto>().ReverseMap();

                config.CreateMap<PageDomain<EmployeeDomain>, BasePageDto<EmployeeDto>>()
                    .ForMember(x => x.ITotalRecords, x => x.MapFrom(c => c.TotalRecord))
                    .ForMember(x => x.ITotalDisplayRecords, x => x.MapFrom(c => c.TotalRecord)).ReverseMap();

                config.CreateMap<PageDomain<Department>, BasePageDto<DepartmentDto>>()
                    .ForMember(x => x.ITotalRecords, x => x.MapFrom(c => c.TotalRecord))
                    .ForMember(x => x.ITotalDisplayRecords, x => x.MapFrom(c => c.TotalRecord)).ReverseMap();

                config.CreateMap<PageDomain<ProductModel>, BasePageDto<ProductModelDto>>()
                    .ForMember(x => x.ITotalRecords, x => x.MapFrom(c => c.TotalRecord))
                    .ForMember(x => x.ITotalDisplayRecords, x => x.MapFrom(c => c.TotalRecord)).ReverseMap();

                config.CreateMap<PageDomain<ProductDomain>, BasePageDto<ProductDto>>()
                    .ForMember(x => x.ITotalRecords, x => x.MapFrom(c => c.TotalRecord))
                    .ForMember(x => x.ITotalDisplayRecords, x => x.MapFrom(c => c.TotalRecord)).ReverseMap();

                //电话类型
                config.CreateMap<PhoneNumberType, EmployeePhoneDto>().ReverseMap();
                //联系类型
                config.CreateMap<ContactType, ContactTypeDto>().ReverseMap();
                //地址类型
                config.CreateMap<AddressType, AddressTypeDto>().ReverseMap();
            });
        }
    }
}
