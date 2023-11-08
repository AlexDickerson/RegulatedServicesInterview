using RegSvcsIntProb.Resources;
using Azure.ResourceManager;
using Azure.Identity;
using Azure.ResourceManager.Automation;
using Azure;

namespace RegSvcsIntProb.Problems
{
    public class Problem3 : IProblem
    {
        public async Task<bool> Run()
        {
            Console.WriteLine("Problem 3");
            bool errored = false;

            DefaultAzureCredential credential = new();
            ArmClient armClient = new(credential);
            string automationAccountName = "InterviewAutoAcc";
            string resourceGroupName = "Interview";

            var success = await DeleteDSCNode(armClient, automationAccountName, resourceGroupName);
            if (!success) errored = true;

            if (errored) Console.WriteLine("Problem 3 failed");
            else Console.WriteLine("Problem 3 Complete");

            await Task.CompletedTask;

            return !errored;
        }

        private async Task<bool> DeleteDSCNode(ArmClient armClient, string automationAccountName, string resourceGroupName)
        {
            var sub = armClient.GetDefaultSubscription();
            var resourceGroup = sub.GetResourceGroups().Get(resourceGroupName).Value;
            var automationAccount = resourceGroup.GetAutomationAccounts().Get(automationAccountName).Value;

            var nodes = automationAccount.GetDscNodes().ToList();

            try
            {
                foreach (var node in nodes)
                {
                    await node.DeleteAsync(WaitUntil.Completed);

                    return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return false;
            }

            return false;
        }
    }
}
