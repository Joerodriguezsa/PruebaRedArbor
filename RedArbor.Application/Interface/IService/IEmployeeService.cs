﻿using RedArbor.Domain.DTO;
using RedArbor.Domain.Entities;

namespace RedArbor.Application.Interface.IService
{
    public interface IEmployeeService
    {
        Task<Employee> GetByIdAsync(int id);
        Task<List<Employee>> GetAllAsync();
        Task CreateAsync(Employee Employee);
        Task<Employee> UpdateAsync(Employee Employee);
        Task<bool> DeleteAsync(int id);
        Task<List<Employee>> GetFilteredAsync(EmployeeFiltrarDTO criteria);
    }
}
