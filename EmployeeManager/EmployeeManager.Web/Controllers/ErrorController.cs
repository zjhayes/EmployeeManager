using EmployeeManager.Shared.Orchestrators;
using EmployeeManager.Shared.ViewModels;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EmployeeManager.Web.Controllers
{
    public class ErrorController : Controller
    {
        private ErrorOrchestrator _errorOrchestrator = new ErrorOrchestrator();
        // GET: Error
        public async Task<ActionResult> Index()
        {
            string errorMsg;
            string stackTrace;

            Exception ex = Server.GetLastError();

            if (ex == null)
            {
                errorMsg = "Unknown Error";
                stackTrace = "Cannot Trace";
            }
            else
            {
                errorMsg = ex.Message;
                stackTrace = ex.StackTrace;
            }

            var errorCount = await _errorOrchestrator.CreateError(new ErrorViewModel
            {
                ErrorId = Guid.NewGuid(),
                ErrorDateTime = DateTime.Now,
                ErrorMessage = errorMsg,
                StackTrace = stackTrace
            });
            return View();
        }
    }
}