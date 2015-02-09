using System;
using RestSharp.Deserializers;

namespace BggSharp.Models.HttpResponse.Plays
{
    public class Play
    {
        public Item Item { get; set; }

        public int Id { get; set; }

        [DeserializeAs(Name = "userid")]
        public int UserId { get; set; }

        public string Date { get; set; }
        public int Quantity { get; set; }
        public int Length { get; set; }
        public string Incomplete { get; set; }

        [DeserializeAs(Name = "nowinstats")]
        public string NowInStats { get; set; }
        public string Location { get; set; }

        public PlayPlayers Players { get; set; }

        public string Comments { get; set; }
    }
}