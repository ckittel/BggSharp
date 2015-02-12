using System.Collections.Generic;
using System.Threading.Tasks;
using BggSharp.Helpers;
using BggSharp.Helpers.MapperExtensions;
using BggSharp.Http;
using BggSharp.Models;
using BggSharp.Models.HttpResponse.HotItems;

namespace BggSharp.Clients
{
    public class HotItemsClient : ClientBase, IHotItemsClient
    {
        public HotItemsClient(IApiConnection connection) : 
            base(connection)
        { }

        public async Task<List<HotItem>> Get(HotItemType type)
        {
            var result = await ApiConnection.Get<HotItemsResponse>(ApiUrls.HotItems, new Dictionary<string, string> {{"type", type.ToApiValue()}}).ConfigureAwait(false);
            return result.ToModel();
        }
    }
}
