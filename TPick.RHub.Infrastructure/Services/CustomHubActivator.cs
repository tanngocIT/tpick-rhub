namespace TPick.RHub.Infrastructure.Services;

// May be used for SimpleInjector
public sealed class CustomHubActivator<THub> : IHubActivator<THub> where THub : Hub
{
    private readonly IServiceScope _scope;

    public CustomHubActivator(IServiceScopeFactory factory)
    {
        _scope = factory.CreateScope();
    }

    public THub Create()
    {
        return _scope.ServiceProvider.GetRequiredService<THub>();
    }

    public void Release(THub hub) => _scope?.Dispose();
}