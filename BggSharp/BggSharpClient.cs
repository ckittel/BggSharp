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
        }

        public HotItemsClient HotItems { get; private set; }
    }
}
