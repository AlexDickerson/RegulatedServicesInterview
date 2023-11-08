namespace RegSvcsIntProb.Resources
{
    public interface ICloudResourceService
    {
        public Task<bool> ReplaceResource(CloudResource resource1, CloudResource resource2);
    }
}
