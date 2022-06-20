using AutoMapper;
using WebApplication1.Models;
using WebApplication1.Models.ViewModel;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Department, DepartmentViewModel>().ReverseMap();
        CreateMap<User, UserViewModel>().ReverseMap();
    }
}