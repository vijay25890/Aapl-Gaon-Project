using API.Models.Domain;
using API.Repository.Interface;
using BackendApi.Data;
using Microsoft.EntityFrameworkCore;

namespace API.Repository.Implimentation
{
    public class LocationsRepository : ILocationsRepository
    {
        private ApplicationDbContext dbContext { get; }
        public LocationsRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Locations> PostLocationDetails(Locations Location)
        {
            await dbContext.Locations.AddAsync(Location);
            await dbContext.SaveChangesAsync();

            return Location;
        }

        public async Task<List<Locations>> GetLocationDetails()
        {
            return await dbContext.Locations.ToListAsync();
        }

        public async Task<Locations> UpdateLocationDetails(Guid id, Locations locations)
        {
            var isPresent = await dbContext.Locations.FirstOrDefaultAsync(X => X.Id == id);

            if (isPresent != null)
            {
                dbContext.Locations.Entry(isPresent).CurrentValues.SetValues(locations);
                await dbContext.SaveChangesAsync();
                return isPresent;
            }

            return null;
        }

        public async Task<bool> DeleteLocationDetails(Guid id)
        {
            var isPresent = await dbContext.Locations.FirstOrDefaultAsync(X => X.Id == id);

            if (isPresent != null)
            {
                dbContext.Locations.Remove(isPresent);
                await dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
