using Autofac;
using Autofac.Integration.WebApi;
using MortgageCalculator.Api.Repos;
using MortgageCalculator.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.Http;

namespace MortgageCalculator.Api
{
    public class AutoFacConfig
    {
        public static void Config()
        {
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<MortgageRepo>().As<IMortgageRepo>();
            builder.RegisterType<MortgageService>().As<IMortgageService>();
            var container = builder.Build();

            AutofacWebApiDependencyResolver resolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = resolver;
        }

        
    }
}