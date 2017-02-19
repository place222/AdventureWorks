﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using BLL.Departments;
using BLL.Departments.Dtos;
using Microsoft.AspNetCore.Mvc;
using BLL.Employees;
using BLL.Employees.Dtos;
using Microsoft.AspNetCore.Cors;
using Microsoft.Extensions.Logging;
using MyFirstCoreWebApi.Models;
using NuGet.Protocol.Core.v3;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MyFirstCoreWebApi.Controllers
{
    [EnableCors("AllowDomain")]
    [Route("api/[controller]")]
    public class DepartmentController : BaseController
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService, ILoggerFactory loggerFactory) : base(loggerFactory)
        {
            _departmentService = departmentService;
        }

        [Route("GetDepartmentsByPage")]
        [HttpPost]
        public async Task<BasePageDto<DepartmentDto>> GetDepartmentsByPage([FromForm]BasePageInput input)
        {
            try
            {
                return await _departmentService.GetDepartmentsByPageAsync(input);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.GetBaseException().Message);
                throw;
            }
        }

        [Route("GetDepartmentById")]
        [HttpGet]
        public async Task<DepartmentDto> GetDepartmentById([FromQuery]int departmentId)
        {
            try
            {
                return await _departmentService.GetDepartmentByIdAsync(departmentId);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.GetBaseException().Message);
                throw;
            }
        }
        [Route("DeleteDepartmentById")]
        [HttpGet]
        public async Task DeleteDepartmentById([FromQuery]int departmentId)
        {
            try
            {
                await _departmentService.DeleteDepartmentByIdAsync(departmentId);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.GetBaseException().Message);
                throw;
            }
        }

        [Route("GetGroups")]
        [HttpPost]
        public async Task<IEnumerable<GroupDto>> GetGroupsAsync()
        {
            try
            {
                return await _departmentService.GetGroupsAsync();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.GetBaseException().Message);
                throw;
            }
        }
    }
}
