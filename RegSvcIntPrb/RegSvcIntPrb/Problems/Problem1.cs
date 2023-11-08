using RegSvcsIntProb.Resources;

namespace RegSvcsIntProb.Problems
{
    public class Problem1 : IProblem
    {
        public async Task<bool> Run()
        {
            Console.WriteLine("Problem 1");

            bool errored = false;

            CloudResource[] resources = new CloudResource[10];
            for (int i = 0; i < resources.Length - 1; i++) resources[i] = new CloudResource();
            
            var resourceCountToDelete = 5;
            var deletedResourceCount = DeleteResources(resources, resourceCountToDelete);
            if (deletedResourceCount != resourceCountToDelete) errored = true;

            var numToUpdate = resources.Length - resourceCountToDelete;
            var updatedResources = UpdateResources(resources.ToList(), numToUpdate);
            if(updatedResources.Count != numToUpdate) errored = true;

            var modifiedSucceessfully = ModifyResource(resources[9]);
            if(!modifiedSucceessfully) errored = true;

            if(errored) Console.WriteLine("Problem 1 failed");
            else Console.WriteLine("Problem 1 Complete");

            await Task.CompletedTask;

            return !errored;
        }

        private int DeleteResources(CloudResource[] resources, int amountToDelete)
        {
            int deleted = 0;
            for (int i = 0; i < amountToDelete - 1; i++)
            {
                resources[i].Delete();
                deleted++;
            }

            return deleted;
        }

        private List<CloudResource> UpdateResources(List<CloudResource> resources, int amountToUpdate)
        {
            var updatedResources = new List<CloudResource>();
            for(int i = 0; i < amountToUpdate; i++)
            {
                updatedResources = new List<CloudResource>() { resources[i].Update() };
            }

            return updatedResources;
        }

        private bool ModifyResource(CloudResource resource)
        {
            if (resource != null) resource.Modify();
            else return false;

            return resource != null;
        }
    }
}
