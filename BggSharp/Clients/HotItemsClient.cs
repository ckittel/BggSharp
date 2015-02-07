using System.Collections.Generic;
using System.Threading.Tasks;
using BggSharp.Helpers;
using BggSharp.Helpers.MapperExtensions;
using BggSharp.Http;
using BggSharp.Models;
using BggSharp.Models.HttpResponse.HotItems;

namespace BggSharp.Clients
{
    public class HotItemsClient : ClientBase
    {
        public HotItemsClient(IApiConnection connection) : 
            base(connection)
        { }

        public Task<List<HotItem>> Get(HotItemType type)
        {
            return ApiConnection.Get<HotItemsResponse>(ApiUrls.HotItems,
                new[] { new KeyValuePair<string, string>("type", type.ToApiValue()) })
                .ContinueWith(t => t.Result.ToModel());
        }

    }
}
