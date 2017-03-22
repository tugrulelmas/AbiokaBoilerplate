using AbiokaBoilerplate.Data;
using AbiokaBoilerplate.Infrastructure.Common.IoC;
using AbiokaBoilerplate.Infrastructure.Framework.IoC;
using AbiokaBoilerplate.Infrastructure.Framework.RestHelper.Attributes;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace AbiokaBoilerplate.Infrastructure.Framework.RestHelper
{
    public class ApiStartup
    {
        public static IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AbiokaDbContext>();
            // Add framework services.
            services.AddMvc().AddControllersAsServices();

            services.AddScoped<CustomActionFilter>();

            var autoFacContainer = new AutoFacContainer();
            DependencyContainer.SetContainer(autoFacContainer);

            Bootstrapper.Initialise();
            ApplicationService.Bootstrapper.Initialise();

            autoFacContainer.ContainerBuilder.Populate(services);

            autoFacContainer.Build();
            return autoFacContainer;
        }
    }
}