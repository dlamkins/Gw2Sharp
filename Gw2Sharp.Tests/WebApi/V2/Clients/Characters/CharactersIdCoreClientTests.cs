using System.Threading.Tasks;
using Gw2Sharp.WebApi.V2.Clients;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.V2.Clients
{
    public class CharactersIdCoreClientTests : BaseCharactersSubEndpointClientTests<ICharactersIdCoreClient>
    {
        protected override bool IsAuthenticated => true;

        protected override ICharactersIdCoreClient CreateClient(IGw2Client gw2Client) =>
            gw2Client.WebApi.V2.Characters["Bob"].Core;

        [Theory]
        [InlineData("TestFiles.Characters.CharactersIdCore.json")]
        public Task BlobTest(string file) => this.AssertBlobDataAsync(this.Client, file);
    }
}
