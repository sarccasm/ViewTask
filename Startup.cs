using ViewTask.Services;

namespace ViewTask;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllersWithViews();
        services.AddTransient<ITimeService, SimpleTimeService>();
    }
}
