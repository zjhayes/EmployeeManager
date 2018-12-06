using EmployeeManager.Domain;
using EmployeeManager.Domain.Entities;
using EmployeeManager.Shared.Orchestrators.Interfaces;
using EmployeeManager.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManager.Shared.Orchestrators
{
    public class EmployeeOrchestrator : IEmployeeOrchestrator
    {
        private EmployeeContext _employeeContext;

        public EmployeeOrchestrator()
        {
            _employeeContext = new EmployeeContext();
        }

        public async Task<int> CreateEmployee(EmployeeViewModel employee)
        {
            _employeeContext.Employees.Add(new Employee
            {
                EmployeeId = employee.EmployeeId,
                FirstName = employee.FirstName,
                MiddleName = employee.MiddleName,
                LastName = employee.LastName,
                DateHired = employee.DateHired,
                BirthDate = employee.BirthDate,
                Salary = employee.Salary,
                Recurrence = employee.Recurrence,
                JobTitle = employee.JobTitle,
                Department = employee.Department,
                Availability = employee.Availability
            });

            return await _employeeContext.SaveChangesAsync();
        }

        public async Task<List<EmployeeViewModel>> GetAllEmployees()
        {
            var employees = await _employeeContext.Employees.Select(x => new EmployeeViewModel
            {
                EmployeeId = x.EmployeeId,
                FirstName = x.FirstName,
                MiddleName = x.MiddleName,
                LastName = x.LastName,
                DateHired = x.DateHired,
                BirthDate = x.BirthDate,
                Salary = x.Salary,
                Recurrence = x.Recurrence,
                JobTitle = x.JobTitle,
                Department = x.Department,
                Availability = x.Availability
            }).ToListAsync();

            return employees;
        }

        public async Task<EmployeeViewModel> GetEmployeeById(Guid employeeId)
        {
            var employee = await _employeeContext.Employees
                .SingleOrDefaultAsync(x => x.EmployeeId == employeeId);
            if(employee == null)
            {
                return new EmployeeViewModel();
            }

            return new EmployeeViewModel()
            {
                EmployeeId = employee.EmployeeId,
                FirstName = employee.FirstName,
                MiddleName = employee.MiddleName,
                LastName = employee.LastName,
                DateHired = employee.DateHired,
                BirthDate = employee.BirthDate,
                Salary = employee.Salary,
                Recurrence = employee.Recurrence,
                JobTitle = employee.JobTitle,
                Department = employee.Department,
                Availability = employee.Availability

            };
        }

        public async Task<EmployeeViewModel> GetEmployee(string searchString)
        {
            Guid guid = new Guid(searchString);
            var employee = await _employeeContext.Employees.FindAsync(guid);


            var viewModel = new EmployeeViewModel
            {
                EmployeeId = employee.EmployeeId,
                FirstName = employee.FirstName,
                MiddleName = employee.MiddleName,
                LastName = employee.LastName,
                DateHired = employee.DateHired,
                BirthDate = employee.BirthDate,
                Salary = employee.Salary,
                Recurrence = employee.Recurrence,
                JobTitle = employee.JobTitle,
                Department = employee.Department,
                Availability = employee.Availability
            };

            return viewModel;
        }

        public async Task<EmployeeViewModel> SearchEmployee(string searchString)
        {
            var employee = await _employeeContext.Employees
                .Where(x => x.FirstName.StartsWith(searchString))
                .FirstOrDefaultAsync();

            if (employee == null)
            {
                return new EmployeeViewModel();
            }

            var viewModel = new EmployeeViewModel
            {
                EmployeeId = employee.EmployeeId,
                FirstName = employee.FirstName,
                MiddleName = employee.MiddleName,
                LastName = employee.LastName,
                DateHired = employee.DateHired,
                BirthDate = employee.BirthDate,
                Salary = employee.Salary,
                Recurrence = employee.Recurrence,
                JobTitle = employee.JobTitle,
                Department = employee.Department,
                Availability = employee.Availability
            };

            return viewModel;
        }

        public async Task<bool> UpdateEmployee(EmployeeViewModel employee)
        {
            var updateEntity = await _employeeContext.Employees.FindAsync(employee.EmployeeId);

            if(updateEntity == null)
            {
                return false;
            }

            updateEntity.FirstName = employee.FirstName;
            updateEntity.MiddleName = employee.MiddleName;
            updateEntity.LastName = employee.LastName;
            updateEntity.DateHired = employee.DateHired;
            updateEntity.BirthDate = employee.BirthDate;
            updateEntity.Salary = employee.Salary;
            updateEntity.Recurrence = employee.Recurrence;
            updateEntity.JobTitle = employee.JobTitle;
            updateEntity.Department = employee.Department;
            updateEntity.Availability = employee.Availability;

            await _employeeContext.SaveChangesAsync();

            return true;
        }
    }
}
