using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AutoMapperDemo.Data.Models;
using AutoMapperDemo.DataAccess;
using AutoMapperDemo.Models.Services;
using AutoMapperDemo.Models.ViewModel;

namespace AutoMapperDemo.Controllers
{
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


        // GET: Users/Edit/5
        // public async Task<IActionResult> Edit(int? id)
        // {
        //     if (id == null || _context.Users == null)
        //     {
        //         return NotFound();
        //     }

        //     var user = await _context.Users.FindAsync(id);
        //     if (user == null)
        //     {
        //         return NotFound();
        //     }
        //     ViewData["DepartmentRefId"] = new SelectList(_context.Departments, "Id", "Description", user.DepartmentRefId);
        //     return View(user);
        // }

        // POST: Users/Edit/5
        //  To protect from overposting attacks, enable the specific properties you want to bind to.
        //  For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,DateOfBirth,Pan,Address,Gender,MobileNumber,Email,Comment,DepartmentRefId")] User user)
        // {
        //     if (id != user.Id)
        //     {
        //         return NotFound();
        //     }

        //     if (ModelState.IsValid)
        //     {
        //         try
        //         {
        //             _context.Update(user);
        //             await _context.SaveChangesAsync();
        //         }
        //         catch (DbUpdateConcurrencyException)
        //         {
        //             if (!UserExists(user.Id))
        //             {
        //                 return NotFound();
        //             }
        //             else
        //             {
        //                 throw;
        //             }
        //         }
        //         return RedirectToAction(nameof(Index));
        //     }
        //     ViewData["DepartmentRefId"] = new SelectList(_context.Departments, "Id", "Description", user.DepartmentRefId);
        //     return View(user);
        // }


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
}

