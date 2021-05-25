using TestApp.Data.Enums;
using TestApp.Services.Database;

namespace TestApp.Services.EmployeeService.Models
{
    public class EmployeeWebModel : WebModelBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public Gender Gender { get; set; }
        public string City { get; set; }
    }
}
