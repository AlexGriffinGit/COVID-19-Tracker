using COVIDTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COVIDTracker.Services
{
    public interface IUserService
    {
        Task<List<Users>> UsersToListAsync();

        Task<Users> GetUserByIdAsync(int? id);

        Task AddUserAsync(Users user);

        Task<Users> FindUserAsync(int? id);

        Task UpdateUserAsync(Users user);

        Task RemoveUserAsync(Users user);

        bool DoesUserExist(int id);
    }
}
