using RestSharp.Deserializers;

namespace BggSharp.Models.HttpResponse.Plays
{
    public class Item
    {
        [DeserializeAs(Name = "subtypes")]
        public ItemSubtypes SubTypes { get; set; }

        public string Name { get; set; }

        [DeserializeAs(Name = "objecttype")]
        public string ObjectType { get; set; }

        [DeserializeAs(Name = "objectid")]
        public int ObjectId { get; set; }
    }
}