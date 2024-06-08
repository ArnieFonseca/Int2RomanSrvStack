using Funq;
using ServiceStack;
using Int2Roman.ServiceInterface;

using Int2Roman.Lib;
using System.Data;
using ServiceStack.Data;
using ServiceStack.OrmLite;

[assembly: HostingStartup(typeof(Int2Roman.AppHost))]

namespace Int2Roman;

public class AppHost : AppHostBase, IHostingStartup
{
    public void Configure(IWebHostBuilder builder) => builder
        .ConfigureServices(services => {
            // Configure ASP.NET Core IOC Dependencies
            
            //Int2RomanService and Library
            services.AddSingleton<Int2RomanService, Int2RomanService>();
            services.AddSingleton<IInt2Roman, IntToRoman>();


        });

    public AppHost() : base("Int2RomanApp", typeof(Int2RomanService).Assembly) {}

    public override void Configure(Container container)
    {
        SetConfig(new HostConfig {
                UseSameSiteCookies = true,
#if DEBUG                
                AdminAuthSecret = "adm1nSecret", // Enable Admin Access with ?authsecret=adm1nSecret
#endif
        });
    }
}
