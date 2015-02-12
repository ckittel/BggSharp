using System.Collections.Generic;

namespace BggSharp.Models.HttpResponse.HotItems
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Justification = "Instantiated by RestSharp")]
    internal class HotItemsResponse
    {
        public List<Item> Items { get; set; }

        public string TermsOfUse { get; set; }
    }
}