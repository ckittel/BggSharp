using RestSharp.Deserializers;

namespace BggSharp.Models.HttpResponse.Plays
{
    public class ItemSubtype
    {
        [DeserializeAs(Name = "value")]
        public string Value { get; set; }
    }
}