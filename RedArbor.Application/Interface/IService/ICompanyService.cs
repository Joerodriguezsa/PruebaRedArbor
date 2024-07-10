using RedArbor.Domain.Entities;

namespace RedArbor.Application.Interface.IService
{
    public interface ICompanyService
    {
        Task<Company> GetByIdAsync(int id);
        Task<List<Company>> GetAllAsync();
        Task CreateAsync(Company Company);
        Task<Company> UpdateAsync(Company Company);
        Task<bool> DeleteAsync(int id);
    }
}
