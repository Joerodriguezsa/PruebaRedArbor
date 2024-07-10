using Microsoft.EntityFrameworkCore;
using RedArbor.Application.Interface.IRepository;
using RedArbor.Domain.Entities;
using System.Data;

namespace RedArbor.Infrastructure.Repository
{
    internal class EmployeeRepository : IEmployeeRepository
    {
        private readonly RedArborDbContext _redArborDbContext;

        public EmployeeRepository(RedArborDbContext redArborDbContext)
        {
            _redArborDbContext = redArborDbContext;
        }

        /// <summary>
        /// Retorna Employee por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Employee> GetByIdAsync(int id)
        {
            return await _redArborDbContext.Employee.FindAsync(id);
        }

        /// <summary>
        /// Retorna Listado de Employee Registrados
        /// </summary>
        /// <returns></returns>
        public async Task<List<Employee>> GetAllAsync()
        {
            return await _redArborDbContext.Employee.Include(w => w.Company).ToListAsync();
        }

        /// <summary>
        /// Creacion de Employee
        /// </summary>
        /// <param name="Employee"></param>
        /// <returns>Registrado Creado</returns>
        public async Task CreateAsync(Employee Employee)
        {
            _redArborDbContext.Employee.Add(Employee);
            await _redArborDbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Actualizacion de Employee
        /// </summary>
        /// <param name="Employee"></param>
        /// <returns></returns>
        public async Task<Employee> UpdateAsync(Employee Employee)
        {
            var existingEmployee = await _redArborDbContext.Employee.FirstOrDefaultAsync(r => r.Id == Employee.Id);

            if (existingEmployee != null)
            {
                existingEmployee.CompanyId = Employee.CompanyId;
                existingEmployee.CreatedOn = Employee.CreatedOn;
                existingEmployee.DeletedOn = Employee.DeletedOn;
                existingEmployee.Email = Employee.Email;
                existingEmployee.Fax = Employee.Fax;
                existingEmployee.Name = Employee.Name;
                existingEmployee.Lastlogin = Employee.Lastlogin;
                existingEmployee.Password = Employee.Password;
                existingEmployee.PortalId = Employee.PortalId;
                existingEmployee.RoleId = Employee.RoleId;
                existingEmployee.StatusId = Employee.StatusId;
                existingEmployee.Telephone = Employee.Telephone;
                existingEmployee.UpdatedOn = Employee.UpdatedOn;
                existingEmployee.Username = Employee.Username;

        _redArborDbContext.Entry(existingEmployee).State = EntityState.Modified;

                try
                {
                    await _redArborDbContext.SaveChangesAsync();
                    return existingEmployee;
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(Employee.Id))
                    {
                        return null;
                    }
                    throw;
                }
            }
            return null;
        }

        /// <summary>
        /// Borrado de registro Employee
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Bool</returns>
        public async Task<bool> DeleteAsync(int id)
        {
            var Employee = await _redArborDbContext.Employee.FindAsync(id);
            if (Employee == null)
            {
                return false;
            }

            _redArborDbContext.Employee.Remove(Employee);
            await _redArborDbContext.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Validacion si existe Employee
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Bool</returns>
        private bool EmployeeExists(int id)
        {
            return _redArborDbContext.Employee.Any(e => e.Id == id);
        }
    }
}
