using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 characters id backstory endpoint.
    /// </summary>
    [EndpointPath("characters/:id/backstory")]
    public class CharactersIdBackstoryClient : BaseCharactersSubClient<CharactersBackstory>, ICharactersIdBackstoryClient
    {
        /// <summary>
        /// Creates a new <see cref="CharactersIdBackstoryClient"/> that is used for the API v2 characters id backstory endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <param name="characterName">The character name.</param>
        public CharactersIdBackstoryClient(IConnection connection, string characterName) : base(connection, characterName) { }
    }
}
