namespace HospitalPharmacyManagementSystem.Web.Infrastructure.Extensions
{
    using System.Reflection;
    using Microsoft.Extensions.DependencyInjection;

    public static class WebApplicationBuilderExtensions
    {
        public static void AddAppServices(this IServiceCollection services, Type serviceType)
        {
            Assembly? serviceAssembly = Assembly.GetAssembly(serviceType);

            if (serviceAssembly is null)
            {
                throw new InvalidOperationException("Invalid service type provided");
            }

            Type[] types = serviceAssembly.GetTypes()
                .Where(t => t.Name.EndsWith("Service") && !t.IsInterface)
                .ToArray();

            foreach (Type t in types)
            {
                Type? type = t.GetInterface($"I{t.Name}");

                if (type is null)
                {
                    throw new InvalidOperationException($"No interface is provided for the service with name {t.Name}");
                }

                services.AddScoped(type, t);
            }
        }
    }
}
