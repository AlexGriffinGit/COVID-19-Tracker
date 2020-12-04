using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using COVIDTracker.Data;
using COVIDTracker.Models;
using COVIDTracker.Services;

namespace COVIDTracker.Controllers
{
    public class UsersController : Controller
    {
        private IUserService _service;

        public UsersController(IUserService service)
        {
            _service = service;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            return View(await _service.UsersToListAsync());
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var users = await _service.GetUserByIdAsync(id);

            if (users == null)
            {
                return NotFound();
            }

            return View(users);
        }

        // GET: Users/Create
        public async Task<IActionResult> Create()
        {
            ViewData["VenueId"] = new SelectList(await _service.VenuesToListAsync(), "VenueId", "VenueName");

            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,Title,Name,DateOfBirth,HouseNumber,StreetName,City,County,Postcode,PhoneNumber,EmailAddress,CheckInTime,CheckOutTime,VenueId")] Users users)
        {
            if (ModelState.IsValid)
            {
                await _service.AddUserAsync(users);

                return RedirectToAction(nameof(Index));
            }
            return View(users);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var users = await _service.FindUserAsync(id);

            if (users == null)
            {
                return NotFound();
            }
            return View(users);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,Title,Name,DateOfBirth,HouseNumber,StreetName,City,County,Postcode,PhoneNumber,EmailAddress,CheckInTime,CheckOutTime,VenueId")] Users users)
        {
            if (id != users.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _service.UpdateUserAsync(users);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsersExists(users.UserId))
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
            return View(users);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var users = await _service.GetUserByIdAsync(id);

            if (users == null)
            {
                return NotFound();
            }

            return View(users);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var users = await _service.FindUserAsync(id);

            await _service.RemoveUserAsync(users);

            return RedirectToAction(nameof(Index));
        }

        private bool UsersExists(int id)
        {
            return _service.DoesUserExist(id);
        }
    }
}
