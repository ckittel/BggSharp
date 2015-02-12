using RestSharp.Deserializers;

namespace BggSharp.Models.HttpResponse.HotItems
{
    // TODO: Convert to a generic ValueOnly class that we can use for all of these "Value Only" responses
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Justification = "Instantiated by RestSharp")]
    internal class YearPublished
    {
        [DeserializeAs(Name = "value")]
        public string Value { get; set; }
    }
}