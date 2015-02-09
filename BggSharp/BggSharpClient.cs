using BggSharp.Clients;
using BggSharp.Http;

namespace BggSharp
{
    public class BggSharpClient
    {
        public BggSharpClient()
        {
            var connection = new ApiConnection();
            HotItems = new HotItemsClient(connection);
            Plays = new PlaysClient(connection);
        }

        public HotItemsClient HotItems { get; private set; }
        public PlaysClient Plays { get; private set; }
    }
}
