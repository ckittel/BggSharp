using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using BggSharp.Models;
using BggSharp.Models.HttpResponse.Plays;

namespace BggSharp.Clients
{
    public interface IPlaysClient
    {
        Task<PlaysResponse> Get(string userName, int page);
        Task<PlaysResponse> Get(string userName, DateTime startDate, DateTime endDate, int page);
        Task<PlaysResponse> Get(string userName, int itemId, int page);
        Task<PlaysResponse> Get(string userName, int itemId, DateTime startDate, DateTime endDate, int page);
        Task<PlaysResponse> Get(int itemId, int page);
        Task<PlaysResponse> Get(int itemId, DateTime startDate, DateTime endDate, int page);
        Task<PlaysResponse> Get(string userName, int itemId, DateTime startDate, DateTime endDate, PlayType? type, PlaySubtype? subtype, int page);
        Task<ReadOnlyCollection<PlaysResponse>> GetAll(string userName);
        Task<ReadOnlyCollection<PlaysResponse>> GetAll(string userName, DateTime startDate, DateTime endDate);
        Task<ReadOnlyCollection<PlaysResponse>> GetAll(string userName, int itemId);
        Task<ReadOnlyCollection<PlaysResponse>> GetAll(string userName, int itemId, DateTime startDate, DateTime endDate);
        Task<ReadOnlyCollection<PlaysResponse>> GetAll(int itemId);
        Task<ReadOnlyCollection<PlaysResponse>> GetAll(int itemId, DateTime startDate, DateTime endDate);
        Task<ReadOnlyCollection<PlaysResponse>> GetAll(string userName, int itemId, DateTime startDate, DateTime endDate, PlayType? type, PlaySubtype? subtype);
    }
}