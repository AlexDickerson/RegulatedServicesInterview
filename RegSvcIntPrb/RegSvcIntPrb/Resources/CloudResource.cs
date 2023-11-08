namespace RegSvcsIntProb.Resources
{
    public interface ICloudResourceAsync
    {
        public Task<CloudResource> UpdateAsync();
        public Task DeleteAsync();
        public Task<CloudResource> ModifyAsync();
    }

    public interface ICloudResource
    {
        public CloudResource Update();
        public void Delete();
        public CloudResource Modify();
        public bool HasData();
    }

    public class CloudResource : ICloudResourceAsync, ICloudResource
    {
        public string Name { get; set; }
        public Guid ID { get; set; }
        public string ResourceType { get; set; }
        public string Description { get; set; }
        public string Data { get; set; }

        public async Task<CloudResource> UpdateAsync()
        {
            await Task.Delay(TimeSpan.FromSeconds(3));

            return this;
        }

        public bool HasData() 
        {
            return !string.IsNullOrEmpty(Data);
        }

        public async Task DeleteAsync()
        {
            await Task.Delay(TimeSpan.FromSeconds(3));
        }

        public async Task<CloudResource> ModifyAsync()
        {
            await Task.Delay(TimeSpan.FromSeconds(3));

            return this;
        }

        public CloudResource Update()
        {
            Thread.Sleep(10);

            return this;
        }

        public void Delete()
        {
            Thread.Sleep(1000);
        }

        public CloudResource Modify()
        {
            Thread.Sleep(10);

            return this;
        }
    }
}
