using COVIDTracker.Data;
using COVIDTracker.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COVIDTracker.Services
{
    public class LogService : ILogService
    {
        private COVIDTrackerContext _context;

        public LogService(COVIDTrackerContext context)
        {
            _context = context;
        }

        public async Task<List<Log>> LogsToListAsync()
        {
            return await _context.Log.ToListAsync();
        }

        public async Task<Log> GetLogByIdAsync(int? id)
        {
            return await _context.Log.FirstOrDefaultAsync(m => m.LogId == id);
        }

        public async Task<List<Users>> UsersToListAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<List<Venues>> VenuesToListAsync()
        {
            return await _context.Venues.ToListAsync();
        }

        public async Task AddLogAsync(Log log)
        {
            log.CheckInTime = DateTime.Now;

            _context.Log.Add(log);

            await _context.SaveChangesAsync();
        }

        public async Task UpdateLogAsync(Log log)
        {
            log.CheckOutTime = DateTime.Now;

            _context.Update(log);

            await _context.SaveChangesAsync();
        }
    }
}
