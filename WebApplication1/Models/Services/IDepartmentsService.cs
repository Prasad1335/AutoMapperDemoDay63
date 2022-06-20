using WebApplication1.Models.ViewModel;

namespace WebApplication1.Models.Services
{
    public interface IDepartmentsService
    {
        Task<List<DepartmentViewModel>> GetAllAsync();
        Task<DepartmentViewModel> GetByIdAsync(int id);
        Task UpdateAsync(DepartmentViewModel userViewModel);
        Task DeleteAsync(int id);
        Task CreateAsync(DepartmentViewModel userViewModel);
    }
}
