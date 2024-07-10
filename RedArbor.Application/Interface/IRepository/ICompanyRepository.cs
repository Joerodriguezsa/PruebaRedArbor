using RedArbor.Domain.Entities;

namespace RedArbor.Application.Interface.IRepository
{
    public interface ICompanyRepository
    {
        Task<Company> GetByIdAsync(int id);
        Task<List<Company>> GetAllAsync();
        Task CreateAsync(Company Company);
        Task<Company> UpdateAsync(Company Company);
        Task<bool> DeleteAsync(int id);
    }
}
