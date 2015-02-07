using System.Collections.Generic;

namespace BggSharp.Models.HttpResponse.HotItems
{
    public class HotItemsResponse
    {
        public List<Item> Items { get; set; }

        public string TermsOfUse { get; set; }
    }
}