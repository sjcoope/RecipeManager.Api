using Autofac;
using Autofac.Integration.WebApi;
using SJCNet.RecipeManager.Data.Uow;
using SJCNet.RecipeManager.Data.Uow.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace SJCNet.RecipeManager.WebAPI.App_Start
{
    public class AutoFacConfig
    {
        internal static void ConfigureDependencyResolver(System.Web.Http.HttpConfiguration config)
        {
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<RecipeManagerUow>().As<IRecipeManagerUow>();

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

        }
    }
}