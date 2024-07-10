using Microsoft.EntityFrameworkCore;
using RedArbor.Application.Interface.IRepository;
using RedArbor.Domain.Entities;
using System.Data;

namespace RedArbor.Infrastructure.Repository
{
    internal class CompanyRepository : ICompanyRepository
    {
        private readonly RedArborDbContext _redArborDbContext;

        public CompanyRepository(RedArborDbContext redArborDbContext)
        {
            _redArborDbContext = redArborDbContext;
        }

        /// <summary>
        /// Retorna Company por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Company> GetByIdAsync(int id)
        {
            return await _redArborDbContext.Company.FindAsync(id);
        }

        /// <summary>
        /// Retorna Listado de Company Registrados
        /// </summary>
        /// <returns></returns>
        public async Task<List<Company>> GetAllAsync()
        {
            return await _redArborDbContext.Company.ToListAsync();
        }

        /// <summary>
        /// Creacion de Company
        /// </summary>
        /// <param name="Company"></param>
        /// <returns>Registrado Creado</returns>
        public async Task CreateAsync(Company Company)
        {
            _redArborDbContext.Company.Add(Company);
            await _redArborDbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Actualizacion de Company
        /// </summary>
        /// <param name="Company"></param>
        /// <returns></returns>
        public async Task<Company> UpdateAsync(Company Company)
        {
            var existingCompany = await _redArborDbContext.Company.FirstOrDefaultAsync(r => r.Id == Company.Id);

            if (existingCompany != null)
            {
                existingCompany.CompanyName = Company.CompanyName;
                existingCompany.State = Company.State;

                _redArborDbContext.Entry(existingCompany).State = EntityState.Modified;

                try
                {
                    await _redArborDbContext.SaveChangesAsync();
                    return existingCompany;
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompanyExists(Company.Id))
                    {
                        return null;
                    }
                    throw;
                }
            }
            return null;
        }

        /// <summary>
        /// Borrado de registro Company
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Bool</returns>
        public async Task<bool> DeleteAsync(int id)
        {
            var Company = await _redArborDbContext.Company.FindAsync(id);
            if (Company == null)
            {
                return false;
            }

            _redArborDbContext.Company.Remove(Company);
            await _redArborDbContext.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Validacion si existe Company
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Bool</returns>
        private bool CompanyExists(int id)
        {
            return _redArborDbContext.Company.Any(e => e.Id == id);
        }
    }
}
