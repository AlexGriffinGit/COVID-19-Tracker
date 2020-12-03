using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using COVIDTracker.Data;
using COVIDTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace COVIDTracker.Services
{
    public class UserService : IUserService
    {
        private COVIDTrackerContext _context;

        public UserService(COVIDTrackerContext context)
        {
            _context = context;
        }

        public async Task<List<Users>> UsersToListAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<Users> GetUserByIdAsync(int? id)
        {
            return await _context.Users.FirstOrDefaultAsync(m => m.UserId == id);
        }

        public async Task AddUserAsync(Users user)
        {
            _context.Add(user);

            await _context.SaveChangesAsync();
        }

        public async Task<Users> FindUserAsync(int? id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task UpdateUserAsync(Users user)
        {
            _context.Update(user);

            await _context.SaveChangesAsync();
        }

        public async Task RemoveUserAsync(Users user)
        {
            _context.Users.Remove(user);

            await _context.SaveChangesAsync();
        }

        public bool DoesUserExist(int id)
        {
            return _context.Users.Any(e => e.UserId == id);
        }
    }
}
