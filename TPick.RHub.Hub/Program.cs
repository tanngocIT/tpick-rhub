using CsMicro.InversionOfControl;
using Microsoft.AspNetCore.Http.Connections;
using TPick.RHub.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseOverrideServiceProviderFactory();

builder.Services
    .AddCsMicro()
    .AddInfrastructure();

var app = builder.Build();
app.MapGet("/health", () => "Ok");
app.UseRouting();
app.UseEndpoints(eBuilder =>
{
    eBuilder.MapHub<HubClient>("/hub",
        o =>
        {
            o.Transports = HttpTransportType.WebSockets;
            o.CloseOnAuthenticationExpiration = false;
        });
});
app.Run();