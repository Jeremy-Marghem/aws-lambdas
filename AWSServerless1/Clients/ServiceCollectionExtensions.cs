using Microsoft.Extensions.DependencyInjection;

namespace AWSServerless1.Clients;
public static class ServiceCollectionExtensions
{
	public static IServiceCollection AddClients(this IServiceCollection services)
	{
		return services;
	}
}
