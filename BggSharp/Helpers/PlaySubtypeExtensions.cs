using System;
using BggSharp.Models;

namespace BggSharp.Helpers
{
    internal static class PlaySubtypeExtensions
    {
        public static string ToApiValue(this PlaySubtype subtype)
        {
            switch (subtype)
            {
                case PlaySubtype.BoardGame:
                    return "boardgame";
                case PlaySubtype.BoardGameExpansion:
                    return "boardgameexpansion";
                case PlaySubtype.RpgItem:
                    return "rpgitem";
                case PlaySubtype.VideoGame:
                    return "videogame";
                default:
                    throw new ArgumentOutOfRangeException("subtype");
            }
        }
    }
}