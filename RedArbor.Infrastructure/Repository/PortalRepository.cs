using Microsoft.EntityFrameworkCore;
using RedArbor.Application.Interface.IRepository;
using RedArbor.Domain.Entities;
using System.Data;

namespace RedArbor.Infrastructure.Repository
{
    internal class PortalRepository : IPortalRepository
    {
        private readonly RedArborDbContext _redArborDbContext;

        public PortalRepository(RedArborDbContext redArborDbContext)
        {
            _redArborDbContext = redArborDbContext;
        }

        /// <summary>
        /// Retorna Portal por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Portal> GetByIdAsync(int id)
        {
            return await _redArborDbContext.Portal.FindAsync(id);
        }

        /// <summary>
        /// Retorna Listado de Portal Registrados
        /// </summary>
        /// <returns></returns>
        public async Task<List<Portal>> GetAllAsync()
        {
            return await _redArborDbContext.Portal.ToListAsync();
        }

        /// <summary>
        /// Creacion de Portal
        /// </summary>
        /// <param name="Portal"></param>
        /// <returns>Registrado Creado</returns>
        public async Task CreateAsync(Portal Portal)
        {
            _redArborDbContext.Portal.Add(Portal);
            await _redArborDbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Actualizacion de Portal
        /// </summary>
        /// <param name="Portal"></param>
        /// <returns></returns>
        public async Task<Portal> UpdateAsync(Portal Portal)
        {
            var existingPortal = await _redArborDbContext.Portal.FirstOrDefaultAsync(r => r.Id == Portal.Id);

            if (existingPortal != null)
            {
                existingPortal.PortalName = Portal.PortalName;
                existingPortal.State = Portal.State;

                _redArborDbContext.Entry(existingPortal).State = EntityState.Modified;

                try
                {
                    await _redArborDbContext.SaveChangesAsync();
                    return existingPortal;
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PortalExists(Portal.Id))
                    {
                        return null;
                    }
                    throw;
                }
            }
            return null;
        }

        /// <summary>
        /// Borrado de registro Portal
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Bool</returns>
        public async Task<bool> DeleteAsync(int id)
        {
            var Portal = await _redArborDbContext.Portal.FindAsync(id);
            if (Portal == null)
            {
                return false;
            }

            _redArborDbContext.Portal.Remove(Portal);
            await _redArborDbContext.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Validacion si existe Portal
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Bool</returns>
        private bool PortalExists(int id)
        {
            return _redArborDbContext.Portal.Any(e => e.Id == id);
        }
    }
}
