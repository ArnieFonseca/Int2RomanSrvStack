using ServiceStack;

[assembly: HostingStartup(typeof(Int2Roman.ConfigureUi))]

namespace Int2Roman;

public class ConfigureUi : IHostingStartup
{
    public void Configure(IWebHostBuilder builder) => builder
        .ConfigureAppHost(appHost => {
            Svg.Load(appHost.RootDirectory.GetDirectory("/assets/svg"));
            Svg.CssFillColor["svg-icons"] = "#E91E63";
        });
}
