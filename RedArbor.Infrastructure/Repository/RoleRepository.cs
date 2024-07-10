using Microsoft.EntityFrameworkCore;
using RedArbor.Application.Interface.IRepository;
using RedArbor.Domain.Entities;
using System.Data;

namespace RedArbor.Infrastructure.Repository
{
    internal class RoleRepository : IRoleRepository
    {
        private readonly RedArborDbContext _redArborDbContext;

        public RoleRepository(RedArborDbContext redArborDbContext)
        {
            _redArborDbContext = redArborDbContext;
        }

        /// <summary>
        /// Retorna Role por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Role> GetByIdAsync(int id)
        {
            return await _redArborDbContext.Role.FindAsync(id);
        }

        /// <summary>
        /// Retorna Listado de Role Registrados
        /// </summary>
        /// <returns></returns>
        public async Task<List<Role>> GetAllAsync()
        {
            return await _redArborDbContext.Role.ToListAsync();
        }

        /// <summary>
        /// Creacion de Role
        /// </summary>
        /// <param name="Role"></param>
        /// <returns>Registrado Creado</returns>
        public async Task CreateAsync(Role Role)
        {
            _redArborDbContext.Role.Add(Role);
            await _redArborDbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Actualizacion de Role
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public async Task<Role> UpdateAsync(Role role)
        {
            var existingRole = await _redArborDbContext.Role.FirstOrDefaultAsync(r => r.Id == role.Id);

            if (existingRole != null)
            {
                existingRole.RoleName = role.RoleName;
                existingRole.State = role.State;

                _redArborDbContext.Entry(existingRole).State = EntityState.Modified;

                try
                {
                    await _redArborDbContext.SaveChangesAsync();
                    return existingRole;
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoleExists(role.Id))
                    {
                        return null;
                    }
                    throw;
                }
            }
            return null;
        }

        /// <summary>
        /// Borrado de registro Role
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Bool</returns>
        public async Task<bool> DeleteAsync(int id)
        {
            var Role = await _redArborDbContext.Role.FindAsync(id);
            if (Role == null)
            {
                return false;
            }

            _redArborDbContext.Role.Remove(Role);
            await _redArborDbContext.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Validacion si existe Role
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Bool</returns>
        private bool RoleExists(int id)
        {
            return _redArborDbContext.Role.Any(e => e.Id == id);
        }
    }
}
