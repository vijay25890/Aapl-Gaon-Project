using API.Data.Domain;

namespace API.Repository.Interface
{
    public interface IAddSarpanch
    {
        Task<AddSarpanch> CreateAsync(AddSarpanch AddSarpanch);
    }
}
