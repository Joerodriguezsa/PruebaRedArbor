using RedArbor.Application.Interface.IRepository;
using RedArbor.Application.Interface.IService;
using RedArbor.Domain.Entities;

namespace RedArbor.Application.Service
{
    public class StatusService: IStatusService
    {
        private readonly IStatusRepository _statusRepository;

        public StatusService(IStatusRepository statusRepository)
        {
            _statusRepository = statusRepository;
        }

        public async Task<Status> GetByIdAsync(int id)
        {
            return await _statusRepository.GetByIdAsync(id);
        }

        public async Task<List<Status>> GetAllAsync()
        {
            return await _statusRepository.GetAllAsync();
        }

        public async Task CreateAsync(Status status)
        {
            await _statusRepository.CreateAsync(status);
        }

        public async Task<bool> UpdateAsync(Status status)
        {
            return await _statusRepository.UpdateAsync(status);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _statusRepository.DeleteAsync(id);
        }
    }
}
