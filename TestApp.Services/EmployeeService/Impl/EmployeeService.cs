using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using TestApp.Framework.Autofac;
using TestApp.Framework.Database;
using TestApp.Services.EmployeeService.Models;

namespace TestApp.Services.EmployeeService.Impl
{
    [InjectableService]
    public class EmployeeService : IEmployeeService
    {
        private readonly IConnectionManager _con;

        public EmployeeService(IConnectionManager con)
        {
            _con = con;
        }

        public async Task<IEnumerable<EmployeeWebModel>> GetEmployees() =>
            await _con.GetConnection()
                .QueryAsync<EmployeeWebModel>(@"
                    select * from employees");

        public async Task<EmployeeWebModel> GetEmployee(long id) =>
            await _con.GetConnection()
                .QueryFirstOrDefaultAsync<EmployeeWebModel>(@"
                    select * from employees
                    where id = @id",
                    new {id});

        public async Task<EmployeeWebModel> CreateEmployee(EmployeeWebModel employee) =>
            await _con.GetConnection()
                .QueryFirstOrDefaultAsync<EmployeeWebModel>(@"
                    insert into employees(first_name, last_name, gender, city)
                    values (@firstName, @lastName, @gender, @city)
                    returning *",
                    new
                    {
                        firstName = employee.FirstName,
                        lastName = employee.LastName,
                        gender = employee.Gender,
                        city = employee.City
                    });

        public async Task<EmployeeWebModel> UpdateEmployee(EmployeeWebModel employee) =>
            await _con.GetConnection()
                .QueryFirstOrDefaultAsync<EmployeeWebModel>(@"
                    update employees
                    set first_name = @firstName,
                        last_name = @lastName,
                        gender = @gender,
                        city = @city,
                        updated_at = now()
                    where id = @id
                    returning *",
                    new
                    {
                        id = employee.Id,
                        firstName = employee.FirstName,
                        lastName = employee.LastName,
                        gender = employee.Gender,
                        city = employee.City
                    });

        public async Task DeleteEmployee(long id) =>
            await _con.GetConnection()
                .ExecuteAsync(@"
                    delete from employees
                    where id = @id",
                    new {id});
    }
}
