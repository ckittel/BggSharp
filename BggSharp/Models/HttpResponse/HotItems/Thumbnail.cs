using RestSharp.Deserializers;

namespace BggSharp.Models.HttpResponse.HotItems
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Justification = "Instantiated by RestSharp")]
    internal class Thumbnail
    {
        [DeserializeAs(Name = "value")]
        public string Value { get; set; }
    }
}