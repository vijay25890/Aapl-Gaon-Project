using API.Models.Domain;

namespace API.Repository.Interface
{
    public interface ILocationsRepository
    {
        Task<Locations> PostLocationDetails(Locations Locations);
        Task<List<Locations>> GetLocationDetails();
        Task<Locations> UpdateLocationDetails(Guid id, Locations locations);
        Task<Boolean> DeleteLocationDetails(Guid id);

    }
}
