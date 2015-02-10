using System.Collections.Generic;
using RestSharp;

namespace BggSharp.Helpers
{
    internal static class RestRequestExtensions
    {
        public static void AddQueryParameters(this RestRequest request, IDictionary<string, string> parameters)
        {
            // TODO: Add Guard

            if (parameters != null)
            {
                foreach (var parameter in parameters)
                {
                    request.AddQueryParameter(parameter.Key, parameter.Value);
                }
            }
        }
    }
}
