using RestSharp.Deserializers;

namespace BggSharp.Models.HttpResponse.Plays
{
    public class Player
    {
        [DeserializeAs(Name = "username")]
        public string Username { get; set; }

        [DeserializeAs(Name = "userid")]
        public int UserId { get; set; }

        public string Name { get; set; }

        [DeserializeAs(Name = "StartPosition")]
        public string StartPosition { get; set; }

        public string Color { get; set; }
        public string Score { get; set; }
        public string New { get; set; }
        public string Rating { get; set; }
        public string Win { get; set; }
    }
}