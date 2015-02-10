using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BggSharp.Helpers;
using BggSharp.Http;
using BggSharp.Models;
using BggSharp.Models.HttpResponse.Plays;

namespace BggSharp.Clients
{
    public class PlaysClient : ClientBase
    {
        public PlaysClient(IApiConnection connection) :
            base(connection)
        { }

        // TODO: Need to convert to cleaner (non-HttpRepsonse bound) model type
        // TODO: Figure out better way to expose paging to user
        // TODO: ...
        // TODO: Profit?

        public Task<PlaysResponse> Get(string username, int page)
        {
            return Get(username, null, null, null, null, null, page);
        }

        public Task<PlaysResponse> Get(string username, DateTime startDate, DateTime endDate, int page)
        {
            return Get(username, null, startDate, endDate, null, null, page);
        }

        public Task<PlaysResponse> Get(string username, int itemId, int page)
        {
            return Get(username, itemId, null, null, null, null, page);
        }

        public Task<PlaysResponse> Get(string username, int itemId, DateTime startDate, DateTime endDate, int page)
        {
            return Get(username, (int?) itemId, startDate, endDate, null, null, page);
        }

        public Task<PlaysResponse> Get(int itemId, int page)
        {
            return Get(null, itemId, null, null, null, null, page);
        }

        public Task<PlaysResponse> Get(int itemId, DateTime startDate, DateTime endDate, int page)
        {
            return Get(null, (int?) itemId, startDate, endDate, null, null, page);
        }

        public Task<PlaysResponse> Get(string username, int itemId, DateTime startDate, DateTime endDate, PlayType? type, PlaySubtype? subtype, int page)
        {
            return Get(username, (int?) itemId, startDate, endDate, type, subtype, page);
        }

        private Task<PlaysResponse> Get(string username, int? itemId, DateTime? startDate, DateTime? endDate, PlayType? type, PlaySubtype? subtype, int page)
        {
            return ApiConnection.Get<PlaysResponse>(ApiUrls.Plays, BuildParams(username, itemId, startDate, endDate, type, subtype, page));
        }

        private static Dictionary<string, string> BuildParams(string username, int? itemId, DateTime? startDate, DateTime? endDate, PlayType? type, PlaySubtype? subtype, int page)
        {
            var result = new Dictionary<string, string>();

            if (itemId.HasValue)
            {
                result.Add("id", itemId.ToString());
            }

            if (!string.IsNullOrWhiteSpace(username))
            {
                result.Add("username", username);
            }

            if (startDate.HasValue)
            {
                result.Add("mindate", startDate.Value.ToString("yyyy-MM-dd"));
            }

            if (endDate.HasValue)
            {
                result.Add("mindate", endDate.Value.ToString("yyyy-MM-dd"));
            }

            if (type.HasValue)
            {
                result.Add("type", type.Value.ToApiValue());
            }

            if (subtype.HasValue)
            {
                result.Add("subtype", subtype.Value.ToApiValue());
            }

            if (page > 1)
            {
                result.Add("page", page.ToString());
            }

            return result.Any() ? result : null;
        }
    }
}
