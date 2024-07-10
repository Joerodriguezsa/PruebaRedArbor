using RedArbor.Domain.Entities;

namespace RedArbor.Application.Interface.IRepository
{
    public interface IStatusRepository
    {
        Task<Status> GetByIdAsync(int id);
        Task<List<Status>> GetAllAsync();
        Task CreateAsync(Status status);
        Task<bool> UpdateAsync(Status status);
        Task<bool> DeleteAsync(int id);
    }
}
