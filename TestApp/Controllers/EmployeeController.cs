using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestApp.Services.EmployeeService;
using TestApp.Services.EmployeeService.Models;

namespace TestApp.Controllers
{
    [Route("employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet, Route("list")]
        [ProducesResponseType(typeof(IEnumerable<EmployeeWebModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> List()
        {
            var employees = await _employeeService.GetEmployees();

            foreach (var employee in employees)
                employee.FullName = $"{employee.FirstName} {employee.LastName}";

            return Ok(employees);
        }

        [HttpGet, Route("{id:long}")]
        [ProducesResponseType(typeof(EmployeeWebModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(long id) =>
            Ok(await _employeeService.GetEmployee(id));

        [HttpPut, Route("add")]
        [ProducesResponseType(typeof(EmployeeWebModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> Create(EmployeeWebModel employee) =>
            Ok(await _employeeService.CreateEmployee(employee));

        [HttpPost, Route("{id:long}")]
        [ProducesResponseType(typeof(EmployeeWebModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> Update([FromRoute] long id, EmployeeWebModel employee)
        {
            employee.Id = id;
            return Ok(await _employeeService.UpdateEmployee(employee));
        }

        [HttpDelete, Route("{id:long}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete([FromRoute] long id)
        {
            await _employeeService.DeleteEmployee(id);
            return Ok();
        }
    }
}
