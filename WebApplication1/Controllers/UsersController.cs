using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using WebApplication1.Models.Data;
using WebApplication1.Models.Services;
using WebApplication1.Models.ViewModel;

namespace WebApplication1.Controllers;

public class UsersController : Controller
{
    private readonly IUsersService _context;

    public UsersController(IUsersService usersService)
    {
        _context = usersService;
    }

    public async Task<IActionResult> Index()
    {
        var usersViewModel = await _context.GetAllAsync();
        return View(usersViewModel);
    }


    public async Task<IActionResult> Details(int id)
    {
        var usersViewModel = await _context.GetByIdAsync(id);
        return View(usersViewModel);
    }

    public IActionResult CreateAsync()
    {
        ViewData["DepartmentRef"] = new SelectList(_context.Departments, "Id", "Description");
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(UserViewModel userViewModel)
    {
        if (!ModelState.IsValid)
            return View(userViewModel);

        await _context.CreateAsync(userViewModel);

        return RedirectToAction("Index");
    }


    public async Task<IActionResult> Edit(int id)
    {
        var departmentViewModel = await _context.GetByIdAsync(id);
        return View(departmentViewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(UserViewModel userViewModel)
    {
        if (!ModelState.IsValid)
            return View(userViewModel);

        await _context.UpdateAsync(userViewModel);

        return RedirectToAction(nameof(Index));
    }
    public async Task<IActionResult> Delete(int id)
    {
        var usersViewModel = await _context.GetByIdAsync(id);
        return View(usersViewModel);
    }

    [HttpPost]
    public async Task<IActionResult> DeleteUser(int id)
    {
        await _context.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
}



    //    private readonly UserManagmentContext _context;

    //    public UsersController(UserManagmentContext context)
    //    {
    //        _context = context;
    //    }

    //    // GET: Users
    //    public async Task<IActionResult> Index()
    //    {
    //        var userManagmentContext = _context.Users.Include(u => u.DepartmentRefNavigation);
    //        return View(await userManagmentContext.ToListAsync());
    //    }

    //    // GET: Users/Details/5
    //    public async Task<IActionResult> Details(int? id)
    //    {
    //        if (id == null || _context.Users == null)
    //        {
    //            return NotFound();
    //        }

    //        var user = await _context.Users
    //            .Include(u => u.DepartmentRefNavigation)
    //            .FirstOrDefaultAsync(m => m.Id == id);
    //        if (user == null)
    //        {
    //            return NotFound();
    //        }

    //        return View(user);
    //    }

    //    // GET: Users/Create
    //    public IActionResult Create()
    //    {
    //        ViewData["DepartmentRef"] = new SelectList(_context.Departments, "Id", "Description");
    //        return View();
    //    }

    //    // POST: Users/Create
    //    // To protect from overposting attacks, enable the specific properties you want to bind to.
    //    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,DateOfBirth,Pan,Address,Gender,MobileNumber,Email,Comment,DepartmentRef")] User user)
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            _context.Add(user);
    //            await _context.SaveChangesAsync();
    //            return RedirectToAction(nameof(Index));
    //        }
    //        ViewData["DepartmentRef"] = new SelectList(_context.Departments, "Id", "Description", user.DepartmentRef);
    //        return View(user);
    //    }

    //    // GET: Users/Edit/5
    //    public async Task<IActionResult> Edit(int? id)
    //    {
    //        if (id == null || _context.Users == null)
    //        {
    //            return NotFound();
    //        }

    //        var user = await _context.Users.FindAsync(id);
    //        if (user == null)
    //        {
    //            return NotFound();
    //        }
    //        ViewData["DepartmentRef"] = new SelectList(_context.Departments, "Id", "Description", user.DepartmentRef);
    //        return View(user);
    //    }

    //    // POST: Users/Edit/5
    //    // To protect from overposting attacks, enable the specific properties you want to bind to.
    //    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,DateOfBirth,Pan,Address,Gender,MobileNumber,Email,Comment,DepartmentRef")] User user)
    //    {
    //        if (id != user.Id)
    //        {
    //            return NotFound();
    //        }

    //        if (ModelState.IsValid)
    //        {
    //            try
    //            {
    //                _context.Update(user);
    //                await _context.SaveChangesAsync();
    //            }
    //            catch (DbUpdateConcurrencyException)
    //            {
    //                if (!UserExists(user.Id))
    //                {
    //                    return NotFound();
    //                }
    //                else
    //                {
    //                    throw;
    //                }
    //            }
    //            return RedirectToAction(nameof(Index));
    //        }
    //        ViewData["DepartmentRef"] = new SelectList(_context.Departments, "Id", "Description", user.DepartmentRef);
    //        return View(user);
    //    }

    //    // GET: Users/Delete/5
    //    public async Task<IActionResult> Delete(int? id)
    //    {
    //        if (id == null || _context.Users == null)
    //        {
    //            return NotFound();
    //        }

    //        var user = await _context.Users
    //            .Include(u => u.DepartmentRefNavigation)
    //            .FirstOrDefaultAsync(m => m.Id == id);
    //        if (user == null)
    //        {
    //            return NotFound();
    //        }

    //        return View(user);
    //    }

    //    // POST: Users/Delete/5
    //    [HttpPost, ActionName("Delete")]
    //    [ValidateAntiForgeryToken]
    //    public async Task<IActionResult> DeleteConfirmed(int id)
    //    {
    //        if (_context.Users == null)
    //        {
    //            return Problem("Entity set 'UserManagmentContext.Users'  is null.");
    //        }
    //        var user = await _context.Users.FindAsync(id);
    //        if (user != null)
    //        {
    //            _context.Users.Remove(user);
    //        }
            
    //        await _context.SaveChangesAsync();
    //        return RedirectToAction(nameof(Index));
    //    }

    //    private bool UserExists(int id)
    //    {
    //      return _context.Users.Any(e => e.Id == id);
    //    }
    //}

