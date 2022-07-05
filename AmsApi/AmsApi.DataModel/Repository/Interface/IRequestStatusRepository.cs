using AmsApi.DataModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmsApi.DataModel.Repository.Interface
{
    public interface IRequestStatusRepository
    {
        Task<Request> SetApprovedStatus(int id, Request request);
        Task<Request> SetRejectedStatus(int id, Request request);
        Task<Request> SetForwardedStatus(int id, Request request);
        Task<Request> SetCompletedStatus(int id, Request request);
    }
}
