using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using COVIDTracker.Data;
using COVIDTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace COVIDTracker.Services
{
    public class VenueService : IVenueService
    {
        private COVIDTrackerContext _context;

        public VenueService(COVIDTrackerContext context)
        {
            _context = context;
        }

        public async Task<List<Venues>> VenuesToListAsync()
        {
            return await _context.Venues.ToListAsync();
        }

        public async Task<Venues> GetVenueByIdAsync(int? id)
        {
            return await _context.Venues.FirstOrDefaultAsync(m => m.VenueId == id);
        }

        public async Task AddVenueAsync(Venues venue)
        {
            _context.Add(venue);

            await _context.SaveChangesAsync();
        }

        public async Task<Venues> FindVenueAsync(int? id)
        {
            return await _context.Venues.FindAsync(id);
        }

        public async Task UpdateVenueAsync(Venues venue)
        {
            _context.Update(venue);

            await _context.SaveChangesAsync();
        }

        public async Task RemoveVenueAsync(Venues venue)
        {
            _context.Venues.Remove(venue);

            await _context.SaveChangesAsync();
        }

        public bool DoesVenueExist(int id)
        {
            return _context.Venues.Any(e => e.VenueId == id);
        }
    }
}
