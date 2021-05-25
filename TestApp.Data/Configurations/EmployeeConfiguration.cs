using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestApp.Data.Models;
using TestApp.Framework.EF;

namespace TestApp.Data.Configurations
{
    public class EmployeeConfiguration : EntityTypeConfigurationBase<Employee>
    {
        public override void Configure(EntityTypeBuilder<Employee> b)
        {
            b.Property(x => x.FirstName).IsRequired();
            b.Property(x => x.LastName).IsRequired();
            b.Property(x => x.Gender).IsRequired();
            b.Property(x => x.City).IsRequired();

            base.Configure(b);
        }
    }
}
