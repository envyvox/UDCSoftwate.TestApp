﻿using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace TestApp.Framework.Web
{
    public class ApiRouteConvention : IApplicationModelConvention
    {
        public void Apply(ApplicationModel application)
        {
            var prefix = new AttributeRouteModel(new RouteAttribute("api"));
            foreach (var selector in application.Controllers.SelectMany(x => x.Selectors))
            {
                selector.AttributeRouteModel = selector.AttributeRouteModel is not null
                    ? AttributeRouteModel.CombineAttributeRouteModel(prefix, selector.AttributeRouteModel)
                    : prefix;
            }
        }
    }
}
