using EmployeeManager.Domain.Entities;
using EmployeeManager.Shared.Orchestrators;
using EmployeeManager.Shared.ViewModels;
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

        [Route("api/v1/employees")]
        public async Task<List<EmployeeViewModel>> GetAllEmployees()
        {
            var employees = await _employeeOrchestrator.GetAllEmployees();

            return employees;
        }

        [Route("api/v1/employees/{id}")]
        public async Task<EmployeeViewModel> GetAllEmployees(string id)
        {
            var employee = await _employeeOrchestrator.GetEmployee(id);
            return employee;
        }
    }
}
