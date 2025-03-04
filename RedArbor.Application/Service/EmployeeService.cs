﻿using RedArbor.Application.Interface.IRepository;
using RedArbor.Application.Interface.IService;
using RedArbor.Domain.DTO;
using RedArbor.Domain.Entities;

namespace RedArbor.Application.Service
{
    public class EmployeeService: IEmployeeService
    {
        private readonly IEmployeeRepository _EmployeeRepository;

        public EmployeeService(IEmployeeRepository EmployeeRepository)
        {
            _EmployeeRepository = EmployeeRepository;
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
            return await _EmployeeRepository.GetByIdAsync(id);
        }

        public async Task<List<Employee>> GetAllAsync()
        {
            return await _EmployeeRepository.GetAllAsync();
        }

        public async Task CreateAsync(Employee Employee)
        {
            await _EmployeeRepository.CreateAsync(Employee);
        }

        public async Task<Employee> UpdateAsync(Employee Employee)
        {
            return await _EmployeeRepository.UpdateAsync(Employee);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _EmployeeRepository.DeleteAsync(id);
        }
        public async Task<List<Employee>> GetFilteredAsync(EmployeeFiltrarDTO criteria)
        {
            return await _EmployeeRepository.GetFilteredAsync(criteria);
        }
    }
}
