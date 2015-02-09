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
                YearPublished = item.YearPublished.Value // TODO: Don't assume there is a year published!
            }).ToList();
        }

        private static Uri ConvertThumbnailValueToUri(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return null;

            if (value.StartsWith("//"))
            {
                value = "http:" + value;
            }

            Uri result;
            Uri.TryCreate(value, UriKind.Absolute, out result);
            return result;
        }
    }
}
