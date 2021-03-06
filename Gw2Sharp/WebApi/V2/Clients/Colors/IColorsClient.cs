
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 colors endpoint.
    /// </summary>
    public interface IColorsClient :
        IAllExpandableClient<Color>,
        IBulkExpandableClient<Color, int>,
        ILocalizedClient<Color>,
        IPaginatedClient<Color>
    {
    }
}
