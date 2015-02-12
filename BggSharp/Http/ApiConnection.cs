using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BggSharp.Helpers;
using RestSharp;

namespace BggSharp.Http
{
    internal class ApiConnection : IApiConnection
    {
        public ApiConnection() :
            this(ApiUrls.Base, "BggSharpClient/1.0")
        { }

        public ApiConnection(Uri baseUri, string userAgent)
        {
            RestClient = new RestClient(baseUri)
            {
                UserAgent = userAgent
            };
        }

        public IRestClient RestClient { get; private set; }

        public Task<T> Get<T>(Uri relativeUri) where T : new()
        {
            return Get<T>(relativeUri, null);
        }

        public Task<T> Get<T>(Uri relativeUri, IDictionary<string, string> requestParameters) where T : new()
        {
            var request = new RestRequest(relativeUri, Method.GET);
            request.AddQueryParameters(requestParameters);

            return RestClient.GetTaskAsync<T>(request);
        }
    }
}
