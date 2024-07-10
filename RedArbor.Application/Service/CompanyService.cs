using RedArbor.Application.Interface.IRepository;
using RedArbor.Application.Interface.IService;
using RedArbor.Domain.Entities;

namespace RedArbor.Application.Service
{
    public class CompanyService: ICompanyService
    {
        private readonly ICompanyRepository _CompanyRepository;

        public CompanyService(ICompanyRepository CompanyRepository)
        {
            _CompanyRepository = CompanyRepository;
        }

        public async Task<Company> GetByIdAsync(int id)
        {
            return await _CompanyRepository.GetByIdAsync(id);
        }

        public async Task<List<Company>> GetAllAsync()
        {
            return await _CompanyRepository.GetAllAsync();
        }

        public async Task CreateAsync(Company Company)
        {
            await _CompanyRepository.CreateAsync(Company);
        }

        public async Task<Company> UpdateAsync(Company Company)
        {
            return await _CompanyRepository.UpdateAsync(Company);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _CompanyRepository.DeleteAsync(id);
        }
    }
}
