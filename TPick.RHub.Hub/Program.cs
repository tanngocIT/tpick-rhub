using System.Security.Claims;
using CsMicro.InversionOfControl;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.IdentityModel.Tokens;
using TPick.RHub.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseOverrideServiceProviderFactory();

builder.Services
    .AddCsMicro()
    .AddInfrastructure();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.Authority = "https://tpick.us.auth0.com/";
    options.Audience = "https://tpick.tk";

    options.TokenValidationParameters = new TokenValidationParameters
    {
        // ValidateIssuerSigningKey = false,
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = "https://tpick.tk",
        ValidIssuer = "https://tpick.us.auth0.com/",
        NameClaimType = ClaimTypes.NameIdentifier,
    };
    options.Events = new JwtBearerEvents()
    {
        OnMessageReceived = context =>
        {
            var accessToken = context.Request.Query["access_token"];

            // If the request is for our hub...
            var path = context.HttpContext.Request.Path;
            if (!string.IsNullOrEmpty(accessToken) &&
                path.StartsWithSegments("/hub"))
            {
                // Read the token out of the query string
                context.Token = accessToken;
            }

            return Task.CompletedTask;
        }
    };
});

var app = builder.Build();
app.MapGet("/health", () => "Ok");
app.UseRouting();
app.UseAuthorization();
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