var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCsMicro().AddInfrastructure();
var app = builder.Build();

app.MapGet("/health", () => "OK");

app.Run();