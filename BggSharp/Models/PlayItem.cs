using System.Collections.Generic;

namespace BggSharp.Models
{
    public class PlayItem
    {
        public PlayItem()
        {
            Subtypes = new List<PlaySubtype>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public PlayType Type { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists", Justification = "Fine for a POCO")]
        public List<PlaySubtype> Subtypes { get; private set; }
    }
}