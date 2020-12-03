using COVIDTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COVIDTracker.Services
{
    public interface IVenueService
    {
        Task<List<Venues>> VenuesToListAsync();

        Task<Venues> GetVenueByIdAsync(int? id);

        Task AddVenueAsync(Venues venue);

        Task<Venues> FindVenueAsync(int? id);

        Task UpdateVenueAsync(Venues venue);

        Task RemoveVenueAsync(Venues venue);

        bool DoesVenueExist(int id);
    }
}
