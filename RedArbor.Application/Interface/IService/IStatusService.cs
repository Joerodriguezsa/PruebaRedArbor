using RedArbor.Domain.Entities;

namespace RedArbor.Application.Interface.IService
{
    public interface IStatusService
    {
        Task<Status> GetByIdAsync(int id);
        Task<List<Status>> GetAllAsync();
        Task CreateAsync(Status status);
        Task<bool> UpdateAsync(Status status);
        Task<bool> DeleteAsync(int id);
    }
}
