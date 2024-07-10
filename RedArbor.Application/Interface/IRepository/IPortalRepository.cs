using RedArbor.Domain.Entities;

namespace RedArbor.Application.Interface.IRepository
{
    public interface IPortalRepository
    {
        Task<Portal> GetByIdAsync(int id);
        Task<List<Portal>> GetAllAsync();
        Task CreateAsync(Portal Portal);
        Task<Portal> UpdateAsync(Portal Portal);
        Task<bool> DeleteAsync(int id);
    }
}
