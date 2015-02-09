using System;

namespace BggSharp.Helpers
{
    public static class ApiUrls
    {
        private static readonly Uri BaseUri = new Uri("http://www.boardgamegeek.com/xmlapi2/", UriKind.Absolute);
        private static readonly Uri HotItemsEndpoint = new Uri("hot", UriKind.Relative);
        private static readonly Uri PlaysEndpoint = new Uri("plays", UriKind.Relative);

        public static Uri Base
        {
            get { return BaseUri; }
        }

        public static Uri HotItems
        {
            get { return HotItemsEndpoint; }
        }

        public static Uri Plays
        {
            get { return PlaysEndpoint; }
        }
    }
}
