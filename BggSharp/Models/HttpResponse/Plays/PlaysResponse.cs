using System.Collections.Generic;
using RestSharp.Deserializers;

namespace BggSharp.Models.HttpResponse.Plays
{
    // TODO: Make internal by providing our own return type and remove warnings below then
    public class PlaysResponse
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly"), 
        System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
        public List<Play> Plays { get; set; }

        [DeserializeAs(Name = "username")]
        public string UserName { get; set; }
        
        public int Total { get; set; }
        public int Page { get; set; }
    }
}
