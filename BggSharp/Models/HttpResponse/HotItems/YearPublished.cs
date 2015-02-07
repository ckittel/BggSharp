using RestSharp.Deserializers;

namespace BggSharp.Models.HttpResponse.HotItems
{
    public class YearPublished
    {
        [DeserializeAs(Name = "value")]
        public string Value { get; set; }
    }
}