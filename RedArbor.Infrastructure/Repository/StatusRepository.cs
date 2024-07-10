using Microsoft.EntityFrameworkCore;
using RedArbor.Application.Interface.IRepository;
using RedArbor.Domain.Entities;

namespace RedArbor.Infrastructure.Repository
{
    internal class StatusRepository : IStatusRepository
    {
        private readonly RedArborDbContext _redArborDbContext;

        public StatusRepository(RedArborDbContext redArborDbContext)
        {
            _redArborDbContext = redArborDbContext;
        }

        /// <summary>
        /// Retorna Status por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Status> GetByIdAsync(int id)
        {
            return await _redArborDbContext.Status.FindAsync(id);
        }

        /// <summary>
        /// Retorna Listado de Status Registrados
        /// </summary>
        /// <returns></returns>
        public async Task<List<Status>> GetAllAsync()
        {
            return await _redArborDbContext.Status.ToListAsync();
        }

        /// <summary>
        /// Creacion de Status
        /// </summary>
        /// <param name="status"></param>
        /// <returns>Registro Creado</returns>
        public async Task CreateAsync(Status status)
        {
            _redArborDbContext.Status.Add(status);
            await _redArborDbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Actualizacion de Status
        /// </summary>
        /// <param name="status"></param>
        /// <returns>Bool</returns>
        public async Task<bool> UpdateAsync(Status status)
        {
            _redArborDbContext.Entry(status).State = EntityState.Modified;
            try
            {
                await _redArborDbContext.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StatusExists(status.Id))
                {
                    return false;
                }
                throw;
            }
        }

        /// <summary>
        /// Borrado de registro Status
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Bool</returns>
        public async Task<bool> DeleteAsync(int id)
        {
            var status = await _redArborDbContext.Status.FindAsync(id);
            if (status == null)
            {
                return false;
            }

            _redArborDbContext.Status.Remove(status);
            await _redArborDbContext.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Vallidacion si existe Status
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Bool</returns>
        private bool StatusExists(int id)
        {
            return _redArborDbContext.Status.Any(e => e.Id == id);
        }
    }
}
