using System.Reflection;

namespace ClaimsApi.Configuration
{
	public static class ServiceConfiguration
	{
		public static IServiceCollection AddApplicationServices(this IServiceCollection services)
		{
			//	TODO - add manual service registrations

			//	TODO - add any additional assemblies to be searched for auto-registration services
			var searchAssemblies = new Assembly[] { typeof(ServiceConfiguration).Assembly };

			//	TODO - call auto-registration method

			return services;
		}

		//	TODO - implement auto-registration method
	}
}