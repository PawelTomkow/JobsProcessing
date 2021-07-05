using System;
using AutoMapper;
using Unity;
using Unity.Lifetime;
using ZavenDotNetInterview.Core.Models;
using ZavenDotNetInterview.Core.Repositories;
using ZavenDotNetInterview.Infrastructure.Config;
using ZavenDotNetInterview.Infrastructure.Repositories;
using ZavenDotNetInterview.Infrastructure.Services;
using ZavenDotNetInterview.Infrastructure.Services.Interfaces;
using ZavenDotNetInterview.Persistence.Context;
using ZavenDotNetInterview.Persistence.Extensions;

namespace ZavenDotNetInterview.App
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your type's mappings here.

            //Singletons
            container.RegisterConfig();
            container.RegisterInstance(AutoMapperConfiguration.GetMapper());
            container.RegisterSingleton<ZavenDotNetInterviewContext>();
            
            //Repos
            container.RegisterType<IJobsRepository, JobsRepository>(new PerResolveLifetimeManager ());
            container.RegisterType<ILogsRepository, LogsRepository>(new PerResolveLifetimeManager ());

            //Services
            container.RegisterType<IJobService, JobService>(new PerResolveLifetimeManager ());
            container.RegisterType<ILogService, LogService>(new PerResolveLifetimeManager ());
            container.RegisterType<IJobProcessorService, JobProcessorService>(new PerResolveLifetimeManager ());
            
        }
    }
}