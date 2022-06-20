using AutoMapper;
using AutoMapperDemo.Data.Models;
using AutoMapperDemo.Models.ViewModel;

namespace AutoMapperDemo
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Department, DepartmentViewModel>().ReverseMap();
            CreateMap<User, UserViewModel>().ReverseMap();
        }
    }
}
