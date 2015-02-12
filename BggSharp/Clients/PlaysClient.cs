using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using BggSharp.Helpers;
using BggSharp.Helpers.MapperExtensions;
using BggSharp.Http;
using BggSharp.Models;
using BggSharp.Models.HttpResponse.Plays;
using Play = BggSharp.Models.Play;

namespace BggSharp.Clients
{
    public class PlaysClient : ClientBase, IPlaysClient
    {
        public PlaysClient(IApiConnection connection) :
            base(connection)
        { }

        // TODO: Need to convert to cleaner (non-HttpRepsonse bound) model type for paged items
        // TODO: ...
        // TODO: Profit?

        public Task<PlaysResponse> Get(string userName, int page)
        {
            return GetPage(userName, null, null, null, null, null, page);
        }

        public Task<PlaysResponse> Get(string userName, DateTime startDate, DateTime endDate, int page)
        {
            return GetPage(userName, null, startDate, endDate, null, null, page);
        }

        public Task<PlaysResponse> Get(string userName, int itemId, int page)
        {
            return GetPage(userName, itemId, null, null, null, null, page);
        }

        public Task<PlaysResponse> Get(string userName, int itemId, DateTime startDate, DateTime endDate, int page)
        {
            return GetPage(userName, itemId, startDate, endDate, null, null, page);
        }

        public Task<PlaysResponse> Get(int itemId, int page)
        {
            return GetPage(null, itemId, null, null, null, null, page);
        }

        public Task<PlaysResponse> Get(int itemId, DateTime startDate, DateTime endDate, int page)
        {
            return GetPage(null, itemId, startDate, endDate, null, null, page);
        }

        public Task<PlaysResponse> Get(string userName, int itemId, DateTime startDate, DateTime endDate, PlayType? type, PlaySubtype? subtype, int page)
        {
            return GetPage(userName, itemId, startDate, endDate, type, subtype, page);
        }

        public Task<ReadOnlyCollection<Play>> GetAll(string userName)
        {
            return GetAll(userName, null, null, null, null, null);
        }

        public Task<ReadOnlyCollection<Play>> GetAll(string userName, DateTime startDate, DateTime endDate)
        {
            return GetAll(userName, null, startDate, endDate, null, null);
        }

        public Task<ReadOnlyCollection<Play>> GetAll(string userName, int itemId)
        {
            return GetAll(userName, itemId, null, null, null, null);
        }

        public Task<ReadOnlyCollection<Play>> GetAll(string userName, int itemId, DateTime startDate, DateTime endDate)
        {
            return GetAll(userName, (int?)itemId, startDate, endDate, null, null);
        }

        public Task<ReadOnlyCollection<Play>> GetAll(int itemId)
        {
            return GetAll(null, itemId, null, null, null, null);
        }

        public Task<ReadOnlyCollection<Play>> GetAll(int itemId, DateTime startDate, DateTime endDate)
        {
            return GetAll(null, (int?)itemId, startDate, endDate, null, null);
        }

        public Task<ReadOnlyCollection<Play>> GetAll(string userName, int itemId, DateTime startDate, DateTime endDate, PlayType? type, PlaySubtype? subtype)
        {
            return GetAll(userName, (int?)itemId, startDate, endDate, type, subtype);
        }

        private async Task<ReadOnlyCollection<Play>> GetAll(string userName, int? itemId, DateTime? startDate, DateTime? endDate, PlayType? type, PlaySubtype? subtype)
        {
            var result = await GetPage(userName, itemId, startDate, endDate, type, subtype, 1).ConfigureAwait(false);

            var playsResponses = new List<PlaysResponse> { result };

            // Start at page 2 and call as needed (may not need to call anymore)
            Parallel.For(2, CalculateTotalNumberOfPages(result.Total, result.Plays.Count) + 1, page =>
            {
                playsResponses.Add(GetPage(userName, itemId, startDate, endDate, type, subtype, page).Result);
            });

            // be nice and kick them back in page order
            return playsResponses.ToFlattenedModel().AsReadOnly();
        }

        private Task<PlaysResponse> GetPage(string userName, int? itemId, DateTime? startDate, DateTime? endDate, PlayType? type, PlaySubtype? subtype, int page)
        {
            return ApiConnection.Get<PlaysResponse>(ApiUrls.Plays, BuildParams(userName, itemId, startDate, endDate, type, subtype, page));
        }

        private static int CalculateTotalNumberOfPages(int totalPlays, int pageSize)
        {
            return (int)Math.Ceiling(totalPlays / (decimal)Math.Max(pageSize, 1));
        }

        private static Dictionary<string, string> BuildParams(string userName, int? itemId, DateTime? startDate, DateTime? endDate, PlayType? type, PlaySubtype? subtype, int page)
        {
            var result = new Dictionary<string, string>();

            if (itemId.HasValue)
            {
                result.Add("id", itemId.ToString());
            }

            if (!string.IsNullOrWhiteSpace(userName))
            {
                result.Add("username", userName);
            }

            if (startDate.HasValue)
            {
                result.Add("mindate", startDate.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture));
            }

            if (endDate.HasValue)
            {
                result.Add("mindate", endDate.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture));
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
                result.Add("page", page.ToString(CultureInfo.InvariantCulture));
            }

            return result.Any() ? result : null;
        }
    }
}
