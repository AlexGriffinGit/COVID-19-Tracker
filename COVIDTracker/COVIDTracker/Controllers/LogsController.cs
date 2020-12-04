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
    public class LogsController : Controller
    {
        private ILogService _service;

        public LogsController(ILogService service)
        {
            _service = service;
        }

        // GET: Logs
        public async Task<IActionResult> Index()
        {
            return View(await _service.LogsToListAsync());
        }

        // GET: Logs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var log = await _service.GetLogByIdAsync(id);

            if (log == null)
            {
                return NotFound();
            }

            return View(log);
        }

        public async Task<IActionResult> CheckInOut()
        {
            ViewData["UserId"] = new SelectList(await _service.UsersToListAsync(), "UserId", "Name");
            ViewData["VenueId"] = new SelectList(await _service.VenuesToListAsync(), "VenueId", "VenueName");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CheckInOut([Bind("User,Venue,CheckInTime,CheckOutTime")] Log log)
        {
            if (ModelState.IsValid)
            {
                await _service.AddLogAsync(log);

                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CheckOut([Bind("User,Venue,CheckInTime,CheckOutTime")] Log log)
        {
            if (ModelState.IsValid)
            {
                await _service.UpdateLogAsync(log);

                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}
