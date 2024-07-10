using RedArbor.Application.Interface.IRepository;
using RedArbor.Application.Interface.IService;
using RedArbor.Domain.Entities;

namespace RedArbor.Application.Service
{
    public class RoleService: IRoleService
    {
        private readonly IRoleRepository _RoleRepository;

        public RoleService(IRoleRepository RoleRepository)
        {
            _RoleRepository = RoleRepository;
        }

        public async Task<Role> GetByIdAsync(int id)
        {
            return await _RoleRepository.GetByIdAsync(id);
        }

        public async Task<List<Role>> GetAllAsync()
        {
            return await _RoleRepository.GetAllAsync();
        }

        public async Task CreateAsync(Role Role)
        {
            await _RoleRepository.CreateAsync(Role);
        }

        public async Task<Role> UpdateAsync(Role Role)
        {
            return await _RoleRepository.UpdateAsync(Role);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _RoleRepository.DeleteAsync(id);
        }
    }
}
