using RestSharp.Deserializers;

namespace BggSharp.Models.HttpResponse.HotItems
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Justification = "Instantiated by RestSharp")]
    internal class Item
    {
        public Thumbnail Thumbnail { get; set; }
        public Name Name { get; set; }
        [DeserializeAs(Name = "yearpublished")]
        public YearPublished YearPublished { get; set; }
        public int Id { get; set; }
        public int Rank { get; set; }
    }

}