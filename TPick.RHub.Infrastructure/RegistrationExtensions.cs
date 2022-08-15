using Autofac;
using CsMicro.Persistence;
using CsMicro.Persistence.EfCore;
using Microsoft.Extensions.Hosting;

namespace TPick.RHub.Infrastructure;

public static class RegistrationExtensions
{
    public static ICsMicroBuilder AddInfrastructure(this ICsMicroBuilder builder)
    {
        builder.Services.AddSignalR(options =>
        {
            options.EnableDetailedErrors = true;
            options.KeepAliveInterval = TimeSpan.FromSeconds(30);
        });

        builder.Services.AddScoped<HubClient>();
        builder.Services.AddScoped(typeof(IHubActivator<>), typeof(CustomHubActivator<>));
        builder.Services.AddScoped<IHubService, HubService>();

        return builder
            .AddCore()
            .AddEventConsumers()
            .AddPersistence(o => { o.UseEfCore(); })
            .AddMessaging(o => { o.UseRedis(); });
    }

    public static IHostBuilder ConfigureAutofacContainer(this IHostBuilder hostBuilder)
    {
        return hostBuilder.ConfigureContainer<ContainerBuilder>((_, builder) =>
        {

        });
    }
}