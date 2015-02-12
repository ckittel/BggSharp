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
                case PlaySubtype.Videogame:
                    return "videogame";
                default:
                    throw new ArgumentOutOfRangeException("subtype");
            }
        }

        public static PlaySubtype FromApiResult(this string subtype)
        {
            if (subtype.Equals("boardgame", StringComparison.OrdinalIgnoreCase))
            {
                return PlaySubtype.BoardGame;
            }

            if (subtype.Equals("boardgameexpansion", StringComparison.OrdinalIgnoreCase))
            {
                return PlaySubtype.BoardGameExpansion;
            }

            if (subtype.Equals("rpgitem", StringComparison.OrdinalIgnoreCase))
            {
                return PlaySubtype.RpgItem;
            }

            if (subtype.Equals("videogame", StringComparison.OrdinalIgnoreCase))
            {
                return PlaySubtype.Videogame;
            }

            throw new ArgumentException("subtype was not one of the expected strings", "subtype");
        }
    }
}