using EmployeeManager.Shared.Orchestrators;
using EmployeeManager.Shared.ViewModels;
using EmployeeManager.Web.Models;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EmployeeManager.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private EmployeeOrchestrator _employeeOrchestrator = new EmployeeOrchestrator();
        // GET: Employee
        public async Task<ActionResult> Index()
        {
            var employeeDisplayModel = new EmployeeDisplayModel()
            {
                Employees = await _employeeOrchestrator.GetAllEmployees()
            };
            return View(employeeDisplayModel);
        }

        public async Task<ActionResult> Create(CreateEmployeeModel employee)
        {
            if(string.IsNullOrWhiteSpace(employee.FirstName))
            {
                return View();
            }

            var updatedCount = await _employeeOrchestrator.CreateEmployee(new EmployeeViewModel
            {
                EmployeeId = Guid.NewGuid(),
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

            return View();
        }
    }
}