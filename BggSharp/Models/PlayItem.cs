using System.Collections.Generic;

namespace BggSharp.Models
{
    public class PlayItem
    {
        public PlayItem()
        {
            Subtypes = new List<string>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> Subtypes { get; private set; }
        public string ObjectType { get; set; }
    }
}