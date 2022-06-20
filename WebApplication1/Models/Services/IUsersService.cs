using System.Collections;
using WebApplication1.Models.ViewModel;

namespace WebApplication1.Models.Services
{
    public interface IUsersService
    {
        IEnumerable Departments { get; }

        // IEnumerable Departments { get; set; }

        Task<List<UserViewModel>> GetAllAsync();
        Task<UserViewModel> GetByIdAsync(int id);
        Task UpdateAsync(UserViewModel userViewModel);
        Task DeleteAsync(int id);
        Task CreateAsync(UserViewModel userViewModel);
    }
}
