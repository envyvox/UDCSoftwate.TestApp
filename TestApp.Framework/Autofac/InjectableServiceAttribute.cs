using System;

namespace TestApp.Framework.Autofac
{
    public class InjectableServiceAttribute : Attribute
    {
        public bool IsSingletone { get; set; }
    }
}
