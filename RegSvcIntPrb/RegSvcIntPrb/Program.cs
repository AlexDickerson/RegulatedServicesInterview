using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RegSvcsIntProb.Problems;
using RegSvcsIntProb.Resources;

namespace RegSvCIntProb
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

            builder.Services.RegisterProblems();
            builder.Services.RegisterServices();

            var problem1 = (IProblem)builder.Services.BuildServiceProvider().GetService<Problem1>()!;
            var problem2 = (IProblem)builder.Services.BuildServiceProvider().GetService<Problem2>()!;
            var problem3 = (IProblem)builder.Services.BuildServiceProvider().GetService<Problem3>()!;

            var problemToRun = args[0];

            switch (problemToRun)
            {
                case "1":
                    await problem1.Run();
                    break;
                case "2":
                    await problem2.Run();
                    break;
                case "3":
                    await problem3.Run();
                    break;
                default:
                    Console.WriteLine("Invalid problem number");
                    break;
            }
        }

        private static void RegisterProblems(this IServiceCollection services)
        {
            services.AddSingleton<Problem1>();
            services.AddSingleton<Problem2>();
            services.AddSingleton<Problem3>();
        }

        private static void RegisterServices(this IServiceCollection services)
        {
            services.AddSingleton<ICloudResourceService, CloudResourceServiceOne>();
            services.AddSingleton<ICloudResourceService, CloudResourceServiceTwo>();
        }
    }
}
