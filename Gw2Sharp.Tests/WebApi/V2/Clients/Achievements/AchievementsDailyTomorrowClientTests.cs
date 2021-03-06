using System.Threading.Tasks;
using Gw2Sharp.WebApi.V2.Clients;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.V2.Clients
{
    public class AchievementsDailyTomorrowClientTests : BaseEndpointClientTests<IAchievementsDailyTomorrowClient>
    {
        protected override IAchievementsDailyTomorrowClient CreateClient(IGw2Client gw2Client) =>
            gw2Client.WebApi.V2.Achievements.Daily.Tomorrow;

        [Theory]
        [InlineData("TestFiles.Achievements.AchievementsDaily.json")]
        public Task BlobTest(string file) => this.AssertBlobDataAsync(this.Client, file);
    }
}
