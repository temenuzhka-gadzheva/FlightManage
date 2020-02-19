using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightManage.Data;
using FlightManage.Entity;
using FlightManage.Models.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlightManage.Controllers
{
    public class UserController : Controller
    {
        private readonly UserDbContext _context;

        private const int PageSize = 10;

        public UserController()
        {
            _context = new UserDbContext();
        }

        //Get: User/Create
        public IActionResult Create()
        {
            UserCreateViewModel model = new UserCreateViewModel();
            return View(model);
        }

        //POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(UserCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User
                {
                    Id = model.Id,
                    Password = model.Password,
                    Email = model.Email,
                    Username = model.Username,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    PersonalNo = model.PersonalNo,
                    Address = model.Address,
                    Telephone = model.Telephone,
                    Role = model.Role

                };

                _context.Add(user);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        //Get: User/Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();

            }

            User user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            UserEditViewModel model = new UserEditViewModel
            {
                Id = user.Id,
                Password = user.Password,
                Email = user.Email,
                Username = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PersonalNo = user.PersonalNo,
                Address = user.Address,
                Telephone = user.Telephone,
                Role = user.Role
            };

            return View(model);
        }

        //POST: User/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(UserEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User
                {
                    Id = model.Id,
                    Password = model.Password,
                    Email = model.Email,
                    Username = model.Username,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    PersonalNo = model.PersonalNo,
                    Address = model.Address,
                    Telephone = model.Telephone,
                    Role = model.Role
                };

                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }

                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Id))
                    {
                        return NotFound();
                    }

                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        //GET: User/Delete

        public async Task<IActionResult> Delete(int Id)
        {
            User user = await _context.Users.FindAsync(Id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id != id);
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}