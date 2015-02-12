using System;
using System.Collections.Generic;

namespace BggSharp.Models
{
    public class Play
    {
        public Play()
        {
            Players = new List<PlayPlayer>();
            Item = new PlayItem();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public int Quantity { get; set; }
        public int Length { get; set; }
        public bool IsIncomplete { get; set; }
        public string Location { get; set; }
        public string Comments { get; set; }
        public bool IsNowInStats { get; set; }

        public PlayItem Item { get; private set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists", Justification = "Fine for a POCO")]
        public List<PlayPlayer> Players { get; private set; }
    }
}
