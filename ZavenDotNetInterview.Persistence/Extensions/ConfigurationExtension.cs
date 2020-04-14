using System.Configuration;
using Unity;
using Unity.Lifetime;
using ZavenDotNetInterview.Persistence.Config;

namespace ZavenDotNetInterview.Persistence.Extensions
{
    public static class ConfigurationExtension
    {
        public static void RegisterConfig(this IUnityContainer unityContainer)
        {
            unityContainer.RegisterInstance(
                new DatabaseConfig(ConfigurationManager.ConnectionStrings["entityFramework"].ConnectionString), 
                new SingletonLifetimeManager());
        }
    }
}