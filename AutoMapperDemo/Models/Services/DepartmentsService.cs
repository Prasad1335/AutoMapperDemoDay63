using AutoMapper;
using AutoMapperDemo.Data.Models;
using AutoMapperDemo.DataAccess;
using AutoMapperDemo.Models.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace AutoMapperDemo.Models.Services;

public class DepartmentsService : IDepartmentsService
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    public DepartmentsService(
        ApplicationDbContext dbContext, 
        IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<List<DepartmentViewModel>> GetAllAsync()
    {
        // EF returns List of DataModel
        var departments = await _dbContext.Departments.ToListAsync();

        // Create a copy of the DataModel into the ViewModel

        //var departmentsViewModel = new List<DepartmentViewModel>();

        //foreach (var department in departments)
        //{
        //    //var departmentViewModel = new DepartmentViewModel
        //    //{
        //    //    Id = department.Id,
        //    //    Name = department.Name,
        //    //    Description = department.Description
        //    //};

        //    var departmentViewModel = _mapper.Map<DepartmentViewModel>(department);

        //    departmentsViewModel.Add(departmentViewModel);
        //}

        var departmentsViewModel = departments
            .Select(d => _mapper.Map<DepartmentViewModel>(d))
            .ToList();

        // return List of ViewModel
        return departmentsViewModel;
    }

    public async Task<DepartmentViewModel> GetByIdAsync(int id)
    {
        // EF returns List of DataModel
        var department = await _dbContext.Departments.SingleAsync(d => d.Id == id);

        //var departmentViewModel = new DepartmentViewModel
        //{
        //    Id = department.Id,
        //    Name = department.Name,
        //    Description = department.Description
        //};

        var departmentViewModel = _mapper.Map<DepartmentViewModel>(department);

        return departmentViewModel;
    }

    public async Task UpdateAsync(DepartmentViewModel departmentViewModel)
    {
        var departmentToUpdate = await _dbContext.Departments.SingleAsync(d => d.Id == departmentViewModel.Id);

        departmentToUpdate.Name = departmentViewModel.Name;
        departmentToUpdate.Description = departmentViewModel.Description;

        _dbContext.Departments.Update(departmentToUpdate);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var departmentToDelete = await _dbContext.Departments.SingleAsync(d => d.Id == id);

        _dbContext.Departments.Remove(departmentToDelete);
        await _dbContext.SaveChangesAsync();
    }

    public async Task CreateAsync(DepartmentViewModel departmentViewModel)
    {
        //var departmentToAdd = new Department
        //{
        //    Name = departmentViewModel.Name,
        //    Description = departmentViewModel.Description
        //};

        var departmentToAdd = _mapper.Map<Department>(departmentViewModel);

        await _dbContext.Departments.AddAsync(departmentToAdd);
        await _dbContext.SaveChangesAsync();
    }
}