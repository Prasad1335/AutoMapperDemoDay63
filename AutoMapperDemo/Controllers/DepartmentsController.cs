using AutoMapperDemo.Models.Services;
using AutoMapperDemo.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace MvcViewModelDemo.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly IDepartmentsService _departmentsService;

        public DepartmentsController(IDepartmentsService departmentsService)
        {
            _departmentsService = departmentsService;
        }

        public async Task<IActionResult> Index()
        {
            var departmentsViewModel = await _departmentsService.GetAllAsync();
            return View(departmentsViewModel);
        }

        public async Task<IActionResult> Details(int id)
        {
            var departmentViewModel = await _departmentsService.GetByIdAsync(id);
            return View(departmentViewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(DepartmentViewModel departmentViewModel)
        {
            if (!ModelState.IsValid)
                return View(departmentViewModel);

            await _departmentsService.CreateAsync(departmentViewModel);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var departmentViewModel = await _departmentsService.GetByIdAsync(id);
            return View(departmentViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(DepartmentViewModel departmentViewModel)
        {
            if (!ModelState.IsValid)
                return View(departmentViewModel);

            await _departmentsService.UpdateAsync(departmentViewModel);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var departmentViewModel = await _departmentsService.GetByIdAsync(id);
            return View(departmentViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            await _departmentsService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
