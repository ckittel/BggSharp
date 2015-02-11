using BggSharp.Clients;

namespace BggSharp
{
    public interface IBggSharpClient
    {
        IHotItemsClient HotItems { get; }
        IPlaysClient Plays { get; }
    }
}