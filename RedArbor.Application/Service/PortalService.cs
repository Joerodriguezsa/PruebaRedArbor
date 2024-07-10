using RedArbor.Application.Interface.IRepository;
using RedArbor.Application.Interface.IService;
using RedArbor.Domain.Entities;

namespace RedArbor.Application.Service
{
    public class PortalService: IPortalService
    {
        private readonly IPortalRepository _PortalRepository;

        public PortalService(IPortalRepository PortalRepository)
        {
            _PortalRepository = PortalRepository;
        }

        public async Task<Portal> GetByIdAsync(int id)
        {
            return await _PortalRepository.GetByIdAsync(id);
        }

        public async Task<List<Portal>> GetAllAsync()
        {
            return await _PortalRepository.GetAllAsync();
        }

        public async Task CreateAsync(Portal Portal)
        {
            await _PortalRepository.CreateAsync(Portal);
        }

        public async Task<Portal> UpdateAsync(Portal Portal)
        {
            return await _PortalRepository.UpdateAsync(Portal);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _PortalRepository.DeleteAsync(id);
        }
    }
}
