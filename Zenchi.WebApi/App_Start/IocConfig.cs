using Zenchi.Services.Core;
using Zenchi.Domain.RepositoryInterfaces;
using Zenchi.Domain.ServiceInterfaces;
using Zenchi.Repository.Ef;
using Zenchi.Services;
using LightInject;
using System;
using System.IO;
using System.Reflection;
using System.Web.Hosting;
using System.Web.Http;

namespace Zenchi
{
    public class IocConfig
    {
        public static ServiceContainer Container = null;

        public static void Register(System.Web.Http.HttpConfiguration config)
        {
            var container = new ServiceContainer();
            Container = container;
            container.RegisterApiControllers(typeof(IocConfig).Assembly);
            container.EnableWebApi(config);
            RegisterServices(container);
        }

        internal static void RegisterServices(ServiceContainer container)
        {
            // Register Logging and Configuration services separately
            container.Register<ILoggingService, NLogLoggingService>(new PerContainerLifetime());
            container.Register<ICacheService, Zenchi.Services.Cache.CacheService>(new PerContainerLifetime());
            IConfigurationRepository configRepository = new ConfigurationRepository();
            container.Register<IConfigurationService, ConfigurationService>(new PerContainerLifetime());


            //Register the Repositories.
            container.Register<IConfigurationRepository, ConfigurationRepository>(new PerContainerLifetime());
            container.Register<IProjectRepository, ProjectRepository>(new PerContainerLifetime());

            //Register the services.
            container.Register<IProjectService, ProjectService>(new PerContainerLifetime());
            

        }

        private static string GetAppDataPath()
        {
            var path = HostingEnvironment.MapPath("~/App_Data");
            if (path == null)
            {
                var uriPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
                path = new Uri(uriPath).LocalPath + "/App_Data";
            }

            return path;
        }
    }
}