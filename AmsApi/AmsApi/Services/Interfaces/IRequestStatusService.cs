using AmsApi.DataModel.Models;
using System.Threading.Tasks;

namespace AmsApi.Services.Interfaces
{
    public interface IRequestStatusService
    {
        Task<Request> SetApprovedStatus(int id, Request request);
        Task<Request> SetRejectedStatus(int id, Request request);
        Task<Request> SetForwardedStatus(int id, Request request);
        Task<Request> SetCompletedStatus(int id, Request request);
    }
}
