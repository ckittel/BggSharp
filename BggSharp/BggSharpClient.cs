using BggSharp.Clients;
using BggSharp.Http;

namespace BggSharp
{
    public class BggSharpClient : IBggSharpClient
    {
        public BggSharpClient()
        {
            var connection = new ApiConnection();
            HotItems = new HotItemsClient(connection);
            Plays = new PlaysClient(connection);
        }

        public IHotItemsClient HotItems { get; private set; }
        public IPlaysClient Plays { get; private set; }
    }
}
