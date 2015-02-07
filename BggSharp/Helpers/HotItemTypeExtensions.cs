using System;
using BggSharp.Models;

namespace BggSharp.Helpers
{
    internal static class HotItemTypeExtensions
    {
        public static string ToApiValue(this HotItemType type)
        {
            switch (type)
            {
                case HotItemType.Boardgame:
                    return "boardgame";
                case HotItemType.Rpg:
                    return "rpg";
                case HotItemType.Videogame:
                    return "videogame";
                case HotItemType.BoardgamePerson:
                    return "boardgameperson";
                case HotItemType.RpgPerson:
                    return "rpgperson";
                case HotItemType.BoardgameCompany:
                    return "boardgamecompany";
                case HotItemType.RpgCompany:
                    return "rpgcompany";
                case HotItemType.VideogameCompany:
                    return "videogamecompany";
                default:
                    throw new ArgumentOutOfRangeException("type");
            }
        }
    }
}
