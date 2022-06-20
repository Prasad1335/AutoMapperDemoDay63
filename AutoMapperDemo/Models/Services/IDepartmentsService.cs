using AutoMapperDemo.Models.ViewModel;

namespace AutoMapperDemo.Models.Services;

public interface IDepartmentsService
{
    Task<List<DepartmentViewModel>> GetAllAsync();
    Task<DepartmentViewModel> GetByIdAsync(int id);
    Task UpdateAsync(DepartmentViewModel departmentViewModel);
    Task DeleteAsync(int id);
    Task CreateAsync(DepartmentViewModel departmentViewModel);
}