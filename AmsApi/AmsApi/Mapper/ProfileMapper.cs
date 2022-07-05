using AmsApi.DataModel.Models;
using AmsApi.ServiceModel.DTOs.Request;
using AmsApi.ServiceModel.DTOs.Response;
using AutoMapper;

namespace AmsApi.Mapper
{
    public class ProfileMapper :Profile
    {
        public ProfileMapper()
        {
            CreateMap<Employee, UserLoginDto>().ReverseMap();
            CreateMap< EmployeeDetailsDto, Employee>().ReverseMap();
            CreateMap<RequestDetailsDto, Request>().ReverseMap();
            CreateMap< RequestDataDto, Request>().ReverseMap();
            CreateMap<EmployeeRequestsDto, Request>().ReverseMap();
        }
    }
}
