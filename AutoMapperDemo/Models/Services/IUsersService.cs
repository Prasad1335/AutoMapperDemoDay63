using AutoMapperDemo.Models.ViewModel;

namespace AutoMapperDemo.Models.Services
{
    public interface IUsersService
    {
        Task<List<UserViewModel>> GetAllAsync();
        Task<UserViewModel> GetByIdAsync(int id);
        Task UpdateAsync(UserViewModel userViewModel);
        Task DeleteAsync(int id);
        Task CreateAsync(UserViewModel userViewModel);
    }
}
