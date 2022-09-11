using CsMicro.Persistence;
using CsMicro.Persistence.EfCore;

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
        builder.Services.AddSingleton<IUserIdProvider, UserIdProvider>();

        return builder
            .AddCore()
            .AddEventConsumers()
            .AddPersistence(o => { o.UseEfCore(); })
            .AddMessaging(o => { o.UseRedis(); });
    }
}