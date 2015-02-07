using RestSharp.Deserializers;

namespace BggSharp.Models.HttpResponse.HotItems
{
    public class Name
    {
        [DeserializeAs(Name = "value")]
        public string Value { get; set; }
    }
}