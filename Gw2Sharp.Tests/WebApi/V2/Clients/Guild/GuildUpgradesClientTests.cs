using System.Threading.Tasks;
using Gw2Sharp.WebApi;
using Gw2Sharp.WebApi.Caching;
using Gw2Sharp.WebApi.Http;
using Gw2Sharp.WebApi.V2.Clients;
using NSubstitute;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.V2.Clients
{
    public class GuildUpgradesClientTests : BaseEndpointClientTests
    {
        public GuildUpgradesClientTests()
        {
            var connection = new Connection(null, Locale.English, Substitute.For<IHttpClient>(), new NullCacheMethod());
            this.client = new Gw2WebApiClient(connection).V2.Guild.Upgrades;
            this.Client = this.client;
        }

        private readonly IGuildUpgradesClient client;

        [Theory]
        [InlineData("TestFiles.Guild.GuildUpgrades.bulk.json")]
        public Task PaginatedTestAsync(string file) => this.AssertPaginatedData(this.client, file);

        [Theory]
        [InlineData("TestFiles.Guild.GuildUpgrades.single.json")]
        public Task GetTestAsync(string file) => this.AssertGetData(this.client, file);

        [Theory]
        [InlineData("TestFiles.Guild.GuildUpgrades.bulk.json")]
        public Task BulkTestAsync(string file) => this.AssertBulkData(this.client, file);

        [Theory]
        [InlineData("TestFiles.Guild.GuildUpgrades.bulk.json")]
        public Task AllTestAsync(string file) => this.AssertAllData(this.client, file);

        [Theory]
        [InlineData("TestFiles.Guild.GuildUpgrades.ids.json")]
        public Task IdsTestAsync(string file) => this.AssertIdsData(this.client, file);
    }
}
