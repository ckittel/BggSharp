using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BggSharp.Helpers;
using BggSharp.Http;
using BggSharp.Models;

namespace BggSharp.Clients
{
    public class HotItemsClient : ClientBase
    {
        public HotItemsClient(IApiConnection connection) : 
            base(connection)
        { }

        public Task<object> Get(HotItemType type)
        {
            return ApiConnection.Get<object>(ApiUrls.HotItems,
                new[] {new KeyValuePair<string, string>("type", ConvertToApiParam(type))});
        }

        private static string ConvertToApiParam(HotItemType type)
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
