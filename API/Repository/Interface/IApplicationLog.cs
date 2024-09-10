using API.Models.Domain;
using API.Repository.Implimentation;

namespace API.Repository.Interface
{
    public interface IApplicationLog
    {
        Task<ApplicationLogs> CreateAsync(ApplicationLogs Application);

    }
}
