using RedArbor.Domain.Entities;

namespace RedArbor.Application.Interface.IRepository
{
    public interface IRoleRepository
    {
        Task<Role> GetByIdAsync(int id);
        Task<List<Role>> GetAllAsync();
        Task CreateAsync(Role Role);
        Task<Role> UpdateAsync(Role Role);
        Task<bool> DeleteAsync(int id);
    }
}
