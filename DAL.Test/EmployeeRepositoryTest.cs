using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Identity;
using DAL.Repositories;
using Microsoft.Extensions.Options;
using MyFirstCoreWeb.Models;
using Xunit;

namespace DAL.Test
{
    public class EmployeeRepositoryTest
    {
        private readonly IEmployeeRepository _employeeRepository = new EmployeeRepository(new OptionsWrapper<ConnectionOptions>(new ConnectionOptions()));


        [Fact]
        public async Task IsUserIsEmployeeTest()
        {
            bool result = await _employeeRepository.IsUserIsEmployee(new User() {Id = 1});

            Assert.True(result);
        }
    }
}
