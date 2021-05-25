using System;
using TestApp.Framework.EF;

namespace TestApp.Data.Models
{
    public class EntityBase : IEntityBase
    {
        public long Id { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
