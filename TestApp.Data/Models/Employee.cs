using TestApp.Data.Enums;

namespace TestApp.Data.Models
{
    public class Employee : EntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public string City { get; set; }
    }
}
