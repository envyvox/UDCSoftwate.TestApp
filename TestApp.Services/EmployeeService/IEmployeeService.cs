using System.Collections.Generic;
using System.Threading.Tasks;
using TestApp.Services.EmployeeService.Models;

namespace TestApp.Services.EmployeeService
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeWebModel>> GetEmployees();
        Task<EmployeeWebModel> GetEmployee(long id);
        Task<EmployeeWebModel> CreateEmployee(EmployeeWebModel employee);
        Task<EmployeeWebModel> UpdateEmployee(EmployeeWebModel employee);
        Task DeleteEmployee(long id);
    }
}
