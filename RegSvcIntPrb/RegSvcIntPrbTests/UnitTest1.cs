using RegSvcsIntProb.Problems;
using RegSvcsIntProb.Resources;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;

namespace RegSvcIntProbTests
{
    public class ProblemTests
    {
        private readonly TestServer testServer;

        public ProblemTests()
        {
            var webBuilder = new WebHostBuilder();
            webBuilder.UseStartup<Startup>();

            testServer = new TestServer(webBuilder);
        }

        [Fact]
        public async Task BigTest1()
        {
            Problem1 problem1 = new();
            var success = await problem1.Run();

            Assert.True(success);
        }

        [Fact]
        public async Task BigTest2()
        {
            ICloudResourceService? cloudResourceService = testServer.Services.GetService<ICloudResourceService>();

            Problem2 problem2 = new(cloudResourceService);
            var success = await problem2.Run();

            Assert.True(success);
        }

        [Fact]
        public async Task BigTest3()
        {
            Environment.SetEnvironmentVariable("AZURE_CLIENT_ID", "ad304010-dac2-4187-ad58-ba9c3e49b311");
            Environment.SetEnvironmentVariable("AZURE_CLIENT_SECRET", "");
            Environment.SetEnvironmentVariable("AZURE_TENANT_ID", "dae34b29-9e17-49e0-87ac-4e81f21d4ffa");
            Problem3 problem3 = new();
            var success = await problem3.Run();

            Assert.True(success);
        }
    }
}