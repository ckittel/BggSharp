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
        //public Task<PlaysResponse> Get(string username, int itemId, string type, DateTime startDate, DateTime endDate, string subtype, int page)
        //{
        //    return ApiConnection.Get<PlaysResponse>(ApiUrls.Plays, BuildParams(username, itemId, type, startDate, endDate, subtype, page));
        //}

        private static IEnumerable<KeyValuePair<string, string>> BuildParams(string username, int itemId, string type, DateTime startDate, DateTime endDate, string subtype, int page)
        {
            // TODO: Only add params based on what is needed
            var result = new List<KeyValuePair<string, string>>(new[] 
            { 
                new KeyValuePair<string, string>("id", itemId.ToString())
                //new KeyValuePair<string, string>("type", type),
                //new KeyValuePair<string, string>("mindate", startDate.ToString("yyyy-MM-dd")),
                //new KeyValuePair<string, string>("maxdate", endDate.ToString("yyyy-MM-dd")),
                //new KeyValuePair<string, string>("subtype", subtype)
            });

            if (!string.IsNullOrWhiteSpace(username))
            {
                result.Add(new KeyValuePair<string, string>("username", username));
            }

            if (page > 0)
            {
                result.Add(new KeyValuePair<string, string>("page", page.ToString()));
            }

            return result;
        }
    }
}
