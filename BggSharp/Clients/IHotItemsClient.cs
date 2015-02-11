using System.Collections.Generic;
using System.Threading.Tasks;
using BggSharp.Models;

namespace BggSharp.Clients
{
    public interface IHotItemsClient
    {
        Task<List<HotItem>> Get(HotItemType type);
    }
}