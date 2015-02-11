using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BggSharp.Models;
using BggSharp.Models.HttpResponse.Plays;

namespace BggSharp.Clients
{
    public interface IPlaysClient
    {
        Task<PlaysResponse> Get(string username, int page);
        Task<PlaysResponse> Get(string username, DateTime startDate, DateTime endDate, int page);
        Task<PlaysResponse> Get(string username, int itemId, int page);
        Task<PlaysResponse> Get(string username, int itemId, DateTime startDate, DateTime endDate, int page);
        Task<PlaysResponse> Get(int itemId, int page);
        Task<PlaysResponse> Get(int itemId, DateTime startDate, DateTime endDate, int page);
        Task<PlaysResponse> Get(string username, int itemId, DateTime startDate, DateTime endDate, PlayType? type, PlaySubtype? subtype, int page);
        Task<List<PlaysResponse>> GetAll(string username);
        Task<List<PlaysResponse>> GetAll(string username, DateTime startDate, DateTime endDate);
        Task<List<PlaysResponse>> GetAll(string username, int itemId);
        Task<List<PlaysResponse>> GetAll(string username, int itemId, DateTime startDate, DateTime endDate);
        Task<List<PlaysResponse>> GetAll(int itemId);
        Task<List<PlaysResponse>> GetAll(int itemId, DateTime startDate, DateTime endDate);
        Task<List<PlaysResponse>> GetAll(string username, int itemId, DateTime startDate, DateTime endDate, PlayType? type, PlaySubtype? subtype);
    }
}