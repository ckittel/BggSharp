using System;

namespace BggSharp.Models
{
    public class HotItem
    {
        public int Id { get; set; }
        public int Rank { get; set; }

        public Uri ThumbnailUrl { get; set; }
        public string Name { get; set; }
        public string YearPublished { get; set; }
    }
}
