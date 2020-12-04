using COVIDTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COVIDTracker.Services
{
    public interface ILogService
    {
        Task<List<Log>> LogsToListAsync();

        Task<Log> GetLogByIdAsync(int? id);

        Task<List<Users>> UsersToListAsync();

        Task<List<Venues>> VenuesToListAsync();

        Task AddLogAsync(Log log);

        Task UpdateLogAsync(Log log);
    }
}
