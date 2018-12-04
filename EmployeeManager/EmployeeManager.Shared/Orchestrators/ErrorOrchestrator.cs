using EmployeeManager.Domain;
using EmployeeManager.Domain.Entities;
using EmployeeManager.Shared.ViewModels;
using System.Threading.Tasks;

namespace EmployeeManager.Shared.Orchestrators
{
    public class ErrorOrchestrator
    {
        private EmployeeContext _employeeContext;

        public ErrorOrchestrator()
        {
            _employeeContext = new EmployeeContext();
        }

        public async Task<int> CreateError(ErrorViewModel error)
        {
            _employeeContext.Errors.Add(new Error
            {
                ErrorId = error.ErrorId,
                ErrorDateTime = error.ErrorDateTime,
                ErrorMessage = error.ErrorMessage,
                StackTrace = error.StackTrace
            });

            return await _employeeContext.SaveChangesAsync();
        }
    }
}
