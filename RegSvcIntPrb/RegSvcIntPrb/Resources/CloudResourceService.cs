namespace RegSvcsIntProb.Resources
{
    public class CloudResourceService : ICloudResourceService
    {
        public async Task<bool> ReplaceResource(CloudResource resource1, CloudResource resource2)
        {
            var resource1Updated = await resource1.UpdateAsync();
            await resource2.DeleteAsync();

            resource1Updated.Data = "Data";

            return resource1Updated.HasData();
        }
    }
}
