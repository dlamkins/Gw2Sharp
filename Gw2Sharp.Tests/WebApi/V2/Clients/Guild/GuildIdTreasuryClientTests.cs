using System.Threading.Tasks;
using Gw2Sharp.WebApi.V2.Clients;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.V2.Clients
{
    public class GuildIdTreasuryClientTests : BaseGuildSubEndpointClientTests<IGuildIdTreasuryClient>
    {
        protected override bool IsAuthenticated => true;

        protected override IGuildIdTreasuryClient CreateClient(IGw2Client gw2Client) =>
            gw2Client.WebApi.V2.Guild["11111111-2222-3333-4444-555555555555"].Treasury;

        [Theory]
        [InlineData("TestFiles.Guild.GuildIdTreasury.json")]
        public Task BlobTest(string file) => this.AssertBlobDataAsync(this.Client, file);
    }
}
