using EmployeeManager.Shared.Orchestrators;
using EmployeeManager.Shared.ViewModels;
using System;
using System.Collections.Generic;
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

        [Route("api/v1/employee")]
        public async Task<List<EmployeeViewModel>> GetAllEmployees()
        {
            var employees = await _employeeOrchestrator.GetAllEmployees();
            return employees;
        }

        [Route("api/v1/employee/{id}")]
        public async Task<List<EmployeeViewModel>> GetEmployee(string id)
        {
            var employee = await _employeeOrchestrator.GetEmployee(id.ToString());
            List<EmployeeViewModel> employeeList = new List<EmployeeViewModel>();
            employeeList.Add(employee);
            return employeeList;
        }
    }
}
