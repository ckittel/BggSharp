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
    public class PlaysClient : ClientBase, IPlaysClient
    {
        public PlaysClient(IApiConnection connection) :
            base(connection)
        { }

        // TODO: Need to convert to cleaner (non-HttpRepsonse bound) model type
        // TODO: ...
        // TODO: Profit?

        public Task<PlaysResponse> Get(string username, int page)
        {
            return GetPage(username, null, null, null, null, null, page);
        }

        public Task<PlaysResponse> Get(string username, DateTime startDate, DateTime endDate, int page)
        {
            return GetPage(username, null, startDate, endDate, null, null, page);
        }

        public Task<PlaysResponse> Get(string username, int itemId, int page)
        {
            return GetPage(username, itemId, null, null, null, null, page);
        }

        public Task<PlaysResponse> Get(string username, int itemId, DateTime startDate, DateTime endDate, int page)
        {
            return GetPage(username, (int?)itemId, startDate, endDate, null, null, page);
        }

        public Task<PlaysResponse> Get(int itemId, int page)
        {
            return GetPage(null, itemId, null, null, null, null, page);
        }

        public Task<PlaysResponse> Get(int itemId, DateTime startDate, DateTime endDate, int page)
        {
            return GetPage(null, (int?)itemId, startDate, endDate, null, null, page);
        }

        public Task<PlaysResponse> Get(string username, int itemId, DateTime startDate, DateTime endDate, PlayType? type, PlaySubtype? subtype, int page)
        {
            return GetPage(username, (int?)itemId, startDate, endDate, type, subtype, page);
        }

        public Task<List<PlaysResponse>> GetAll(string username)
        {
            return GetAll(username, null, null, null, null, null);
        }

        public Task<List<PlaysResponse>> GetAll(string username, DateTime startDate, DateTime endDate)
        {
            return GetAll(username, null, startDate, endDate, null, null);
        }

        public Task<List<PlaysResponse>> GetAll(string username, int itemId)
        {
            return GetAll(username, itemId, null, null, null, null);
        }

        public Task<List<PlaysResponse>> GetAll(string username, int itemId, DateTime startDate, DateTime endDate)
        {
            return GetAll(username, (int?)itemId, startDate, endDate, null, null);
        }

        public Task<List<PlaysResponse>> GetAll(int itemId)
        {
            return GetAll(null, itemId, null, null, null, null);
        }

        public Task<List<PlaysResponse>> GetAll(int itemId, DateTime startDate, DateTime endDate)
        {
            return GetAll(null, (int?)itemId, startDate, endDate, null, null);
        }

        public Task<List<PlaysResponse>> GetAll(string username, int itemId, DateTime startDate, DateTime endDate, PlayType? type, PlaySubtype? subtype)
        {
            return GetAll(username, (int?)itemId, startDate, endDate, type, subtype);
        }

        private Task<List<PlaysResponse>> GetAll(string username, int? itemId, DateTime? startDate, DateTime? endDate, PlayType? type, PlaySubtype? subtype)
        {
            return GetPage(username, itemId, startDate, endDate, type, subtype, 1)
                .ContinueWith(at =>
                {
                    var playsResponses = new List<PlaysResponse> { at.Result };

                    // Start at page 2 and call as needed (may not need to call anymore)
                    Parallel.For(2, CalculateTotalNumberOfPages(at.Result.Total, at.Result.Plays.Count) + 1, page =>
                    {
                        playsResponses.Add(GetPage(username, itemId, startDate, endDate, type, subtype, page).Result);
                    });

                    // be nice and kick them back in page order
                    return playsResponses.OrderBy(r => r.Page).ToList();
                });
        }

        private Task<PlaysResponse> GetPage(string username, int? itemId, DateTime? startDate, DateTime? endDate, PlayType? type, PlaySubtype? subtype, int page)
        {
            return ApiConnection.Get<PlaysResponse>(ApiUrls.Plays, BuildParams(username, itemId, startDate, endDate, type, subtype, page));
        }

        private static int CalculateTotalNumberOfPages(int totalPlays, int pageSize)
        {
            return (int)Math.Ceiling(totalPlays / (decimal)pageSize);
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
