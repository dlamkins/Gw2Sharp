using System.Threading.Tasks;
using Gw2Sharp.WebApi.V2.Clients;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.V2.Clients
{
    public class AccountRaidsClientTests : BaseEndpointClientTests<IAccountRaidsClient>
    {
        protected override bool IsAuthenticated => true;

        protected override IAccountRaidsClient CreateClient(IGw2Client gw2Client) =>
            gw2Client.WebApi.V2.Account.Raids;

        [Theory]
        [InlineData("TestFiles.Account.AccountRaids.json")]
        public Task BlobTest(string file) => this.AssertBlobDataAsync(this.Client, file);
    }
}
