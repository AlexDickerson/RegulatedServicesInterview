using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RegSvcsIntProb.Resources;

namespace RegSvcIntProbTests
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ICloudResourceService, CloudResourceServiceOne>();
            services.AddSingleton<ICloudResourceService, CloudResourceServiceTwo>();
        }

        public static void Configure()
        {
        }
    }
}
