using CsMicro.InversionOfControl;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.Mvc;
using TPick.RHub.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseOverrideServiceProviderFactory();
builder.Host.ConfigureAutofacContainer();

builder.Services
    .AddCsMicro()
    .AddInfrastructure();

var app = builder.Build();
app.MapGet("/health", ([FromServices] IHubContext<HubClient> hubClient) =>
{
    HubService.SetHubContext(hubClient);
    Results.Ok("Ok");
});
app.UseRouting();
app.UseEndpoints(eBuilder =>
{
    eBuilder.MapHub<HubClient>("/hub",
        o => { o.Transports = HttpTransportType.WebSockets | HttpTransportType.LongPolling; });
});
app.Run();