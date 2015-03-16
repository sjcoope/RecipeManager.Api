using SJCNet.RecipeManager.WebAPI.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace SJCNet.RecipeManager.WebAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AutoFacConfig.ConfigureDependencyResolver(GlobalConfiguration.Configuration);
        }
    }
}
