using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BggSharp.Http
{
    public interface IApiConnection
    {
        Task<T> Get<T>(Uri relativeUri) where T : new();
        Task<T> Get<T>(Uri relativeUri, IDictionary<string, string> requestParameters) where T : new();
    }
}