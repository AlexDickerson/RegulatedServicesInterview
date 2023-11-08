using RegSvcsIntProb.Resources;
using System.Text.Json;

namespace RegSvcsIntProb.Problems
{
    public class Problem2 : IProblem
    {
        private readonly ICloudResourceService cloudResourceService;

        public Problem2(ICloudResourceService cloudResourceService)
        {
            this.cloudResourceService = cloudResourceService;
        }

        public async Task<bool> Run()
        {
            Console.WriteLine("Problem 2");
            bool errored = false;

            CloudResource[] resources = new CloudResource[10];
            for (int i = 0; i < resources.Length; i++) resources[i] = new CloudResource();

            string resourceJSON = @"
            {
                ""Name"": ""Resource1"",
                ""ID"": ""12345678-1234-1234-1234-123456789012"",
                ""ResourceType"": ""ResourceType"",
                ""Description"": ""Description"",
            }";

            var success = ParseNewResource(resourceJSON);
            if (!success) errored = true;

            success = await cloudResourceService.ReplaceResource(resources[0], resources[1]);
            if (!success) errored = true;

            var updateTask = UpdateResource(resources.ToList());
            await Task.WhenAny(updateTask, Task.Delay(TimeSpan.FromSeconds(10)));
            if (!updateTask.IsCompleted) errored = true;

            if(errored) Console.WriteLine("Problem 2 failed");
            else Console.WriteLine("Problem 2 Complete");

            await Task.CompletedTask;

            return !errored;
        }

        private bool ParseNewResource(string resourceJSON)
        {
            try
            {
                var resource = JsonSerializer.Deserialize<CloudResource>(resourceJSON)!;

                return resource.HasData();
            }
            catch (Exception e)
            {
                return false;
            }
        }

        private async Task<bool> UpdateResource(List<CloudResource> resources)
        {
            foreach (CloudResource resource in resources)
            {
                await resource.UpdateAsync();
            }

            return true;
        }
    }
}
