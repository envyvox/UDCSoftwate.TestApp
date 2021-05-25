using System;

namespace TestApp.Framework.EF
{
    public interface IEntityBase
    {
        long Id { get; set; }
        DateTimeOffset CreatedAt { get; set; }
        DateTimeOffset UpdatedAt { get; set; }
    }
}
