using System;

namespace TestApp.Services.Database
{
    public class WebModelBase
    {
        public long Id { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
