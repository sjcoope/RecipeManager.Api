using SJCNet.RecipeManager.WebAPI.App_Start;
using System.Web.Http;
using FluentValidation.WebApi;

namespace SJCNet.RecipeManager.WebAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AutoFacConfig.ConfigureDependencyResolver(GlobalConfiguration.Configuration);
            FluentValidationModelValidatorProvider.Configure(GlobalConfiguration.Configuration);
        }
    }
}
