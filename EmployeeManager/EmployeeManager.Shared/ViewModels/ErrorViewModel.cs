
using System;

namespace EmployeeManager.Shared.ViewModels
{
    public class ErrorViewModel
    {
        public Guid ErrorId { get; set; }
        public DateTime ErrorDateTime { get; set; }
        public string ErrorMessage { get; set; }
        public string StackTrace { get; set; }
    }
}
