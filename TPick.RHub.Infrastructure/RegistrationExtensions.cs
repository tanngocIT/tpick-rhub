using TPick.RHub.Infrastructure.Services;

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
        builder.Services.AddScoped<IHubService, HubService>();
        
        return builder
            .AddCore()
            .AddEventConsumers()
            .AddMessaging(o => { o.UseRedis(); });
    }
}