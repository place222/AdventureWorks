using System.Threading.Tasks;
using BLL.Employees.Dtos;

namespace BLL.Employees
{
    public interface IEmployeeService
    {
        Task<BasePageDto<EmployeeDto>> GetEmployeesByPageAsync(BasePageInput input);
    }
}
