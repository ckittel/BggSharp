using System.Collections.Generic;
using RestSharp.Deserializers;

namespace BggSharp.Models.HttpResponse.Plays
{
    public class PlaysResponse
    {
        public List<Play> Plays { get; set; }

        [DeserializeAs(Name = "username")]
        public string UserName { get; set; }
        
        public int Total { get; set; }
        public int Page { get; set; }
    }
}
