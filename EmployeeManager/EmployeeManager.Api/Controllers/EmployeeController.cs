using EmployeeManager.Api.Models;
using EmployeeManager.Domain.Entities;
using EmployeeManager.Shared.Orchestrators;
using EmployeeManager.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace EmployeeManager.Api.Controllers
{
    [Route("api/v1/employees")]
    public class EmployeeController : ApiController
    {
        private EmployeeOrchestrator _employeeOrchestrator;

        public EmployeeController()
        {
            _employeeOrchestrator = new EmployeeOrchestrator();
        }

        [HttpGet]
        [Route("api/v1/employees")]
        public async Task<List<EmployeeModel>> GetAllEmployees()
        {
            var employees = await _employeeOrchestrator.GetAllEmployees();

            var employeeModel = employees.Select(x => new EmployeeModel
            {
                EmployeeId = x.EmployeeId,
                FirstName = x.FirstName,
                MiddleName = x.MiddleName
            }).ToList();

            return employeeModel;
        }

        public async Task<EmployeeModel> GetEmployeeById(Guid employeeId)
        {
            var employee = await _employeeOrchestrator.GetEmployeeById(employeeId);

            var employeeModel = new EmployeeModel
            {
                FirstName = employee.FirstName,
                MiddleName = employee.MiddleName,
                LastName = employee.LastName,
                BirthDate = employee.BirthDate,
                Department = employee.Department
            };

            return employeeModel;
        }

        /*
        [Route("api/v1/employees/{id}")]
        public async Task<EmployeeViewModel> GetAllEmployees(string id)
        {
            var employee = await _employeeOrchestrator.GetEmployee(id);
            return employee;
        }*/


    }
}
