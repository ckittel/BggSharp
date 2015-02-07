using RestSharp.Deserializers;

namespace BggSharp.Models.HttpResponse.HotItems
{
    public class Thumbnail
    {
        [DeserializeAs(Name = "value")]
        public string Value { get; set; }
    }
}