using System;
using System.Collections.Generic;
using System.Linq;
using BggSharp.Models;
using BggSharp.Models.HttpResponse.HotItems;

namespace BggSharp.Helpers.MapperExtensions
{
    internal static class HotItemsResponseExtensions
    {
        public static List<HotItem> ToModel(this HotItemsResponse response)
        {
            return response.Items.Select(item => new HotItem
            {
                Id = item.Id,
                Name = item.Name.Value,
                Rank = item.Rank,
                ThumbnailUrl = ConvertThumbnailValueToUri(item.Thumbnail.Value),
                YearPublished = (item.YearPublished != null) ? item.YearPublished.Value : string.Empty // At this time, only boardgame and rpg provide this value
            }).ToList();
        }

        private static Uri ConvertThumbnailValueToUri(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return null;

            // for some reason the URLs don't start with http://, they start with only //
            // TODO: does HTTPS work here?  Should we expose this as an option, or just force HTTPS (or continue to force HTTP)?
            if (value.StartsWith("//", StringComparison.OrdinalIgnoreCase))
            {
                value = "http:" + value;
            }

            Uri result;
            Uri.TryCreate(value, UriKind.Absolute, out result);
            return result;
        }
    }
}
