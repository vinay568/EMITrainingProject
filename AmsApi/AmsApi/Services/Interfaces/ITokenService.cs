using AmsApi.DataModel.Models;

namespace AmsApi.Services.Interfaces
{
    public interface ITokenService
    {
        public string CreateToken(Employee employee);
    }
}
