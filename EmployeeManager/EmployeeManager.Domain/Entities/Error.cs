using System;

namespace EmployeeManager.Domain.Entities
{
    public class Error
    {
        public Guid ErrorId { get; set; }
        public DateTime ErrorDateTime { get; set; }
        public string ErrorMessage { get; set; }
        public string StackTrace { get; set; }
    }
}
