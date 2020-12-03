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
    public class VenuesController : Controller
    {
        private IVenueService _service;

        public VenuesController(IVenueService service)
        {
            _service = service;
        }

        // GET: Venues
        public async Task<IActionResult> Index()
        {
            return View(await _service.VenuesToListAsync());
        }

        // GET: Venues/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venues = await _service.GetVenueByIdAsync(id);

            if (venues == null)
            {
                return NotFound();
            }

            return View(venues);
        }

        // GET: Venues/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Venues/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VenueId,VenueName,Capacity,BuildingNumber,StreetName,City,County,Postcode,PhoneNumber,EmailAddress")] Venues venues)
        {
            if (ModelState.IsValid)
            {
                await _service.AddVenueAsync(venues);

                return RedirectToAction(nameof(Index));
            }
            return View(venues);
        }

        // GET: Venues/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venues = await _service.FindVenueAsync(id);

            if (venues == null)
            {
                return NotFound();
            }
            return View(venues);
        }

        // POST: Venues/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VenueId,VenueName,Capacity,BuildingNumber,StreetName,City,County,Postcode,PhoneNumber,EmailAddress")] Venues venues)
        {
            if (id != venues.VenueId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _service.UpdateVenueAsync(venues);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VenuesExists(venues.VenueId))
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
            return View(venues);
        }

        // GET: Venues/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venues = await _service.GetVenueByIdAsync(id);

            if (venues == null)
            {
                return NotFound();
            }

            return View(venues);
        }

        // POST: Venues/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var venues = await _service.FindVenueAsync(id);

            await _service.RemoveVenueAsync(venues);

            return RedirectToAction(nameof(Index));
        }

        private bool VenuesExists(int id)
        {
            return _service.DoesVenueExist(id);
        }
    }
}
