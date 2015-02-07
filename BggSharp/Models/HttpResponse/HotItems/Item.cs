using System.Collections.Generic;
using RestSharp.Deserializers;

namespace BggSharp.Models.HttpResponse.HotItems
{
    public class Item
    {
        public Thumbnail Thumbnail { get; set; }
        public Name Name { get; set; }
        [DeserializeAs(Name = "yearpublished")]
        public YearPublished YearPublished { get; set; }
        public int Id { get; set; }
        public int Rank { get; set; }
    }

}