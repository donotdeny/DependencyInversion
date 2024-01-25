using DependencyInversion.Interfaces;
using DependencyInversion.MySQL;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DependencyInversion
{
    public static class HostBaseFactory
    {
        public static void InjectDatabase(IConfiguration configuration, IServiceCollection serviceCollection)
        {
            string? database = configuration.GetValue<string>("Database");
            if (database != null)
            {
                string objectToInstantiate = $"DependencyInversion.{database}.{database}Factory, DependencyInversion";
                Type? objectType = Type.GetType(objectToInstantiate);
                if (objectType != null)
                {
                    var instantiatedObject = Activator.CreateInstance(objectType) as IFactory ?? throw new Exception();
                    instantiatedObject.InjectSQL(serviceCollection);
                }
                else
                {
                    throw new Exception($"AssemblyQualifiedName {objectToInstantiate} not found");
                }
            }
            else
            {
                throw new Exception("Config database not found");
            }
        }
    }
}
