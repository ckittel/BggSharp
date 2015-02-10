using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BggSharp.Helpers;
using BggSharp.Http;
using BggSharp.Models.HttpResponse.Plays;

namespace BggSharp.Clients
{
    public class PlaysClient : ClientBase
    {
        public PlaysClient(IApiConnection connection) :
            base(connection)
        { }

        // TODO: Need to introduce overloads
        // TODO: Need to convert to cleaner (non-HttpRepsonse bound) model type
        // TODO: Figure out better way to expose paging to user
        // TODO: ...
        // TODO: Profit?
        public Task<PlaysResponse> Get(string username, int itemId, string type, DateTime startDate, DateTime endDate, string subtype, int page)
        {
            return ApiConnection.Get<PlaysResponse>(ApiUrls.Plays, BuildParams(username, itemId, type, startDate, endDate, subtype, page));
        }

        private static IEnumerable<KeyValuePair<string, string>> BuildParams(string username, int itemId, string type, DateTime startDate, DateTime endDate, string subtype, int page)
        {
            // TODO: Only add params based on what is needed
            var result = new Dictionary<string, string> 
            { 
                {"id", itemId.ToString()},
                {"type", type},
                {"mindate", startDate.ToString("yyyy-MM-dd")},
                {"maxdate", endDate.ToString("yyyy-MM-dd")},
                {"subtype", subtype}
            };

            if (!string.IsNullOrWhiteSpace(username))
            {
                result.Add("username", username);
            }

            if (page > 1)
            {
                result.Add("page", page.ToString());
            }

            return result;
        }
    }
}
