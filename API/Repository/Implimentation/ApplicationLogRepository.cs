using API.Models.Domain;
using API.Repository.Interface;

namespace API.Repository.Implimentation
{
    public class ApplicationLogRepository : IApplicationLog
    {
        public Task<ApplicationLogs> CreateAsync(ApplicationLogs Application)
        {
            throw new NotImplementedException();
        }
    }
}
