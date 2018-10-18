using System;
using System.ComponentModel.DataAnnotations;
using static EmployeeManager.Domain.Entities.Employee;

namespace EmployeeManager.Shared.ViewModels
{
    public class EmployeeViewModel
    {
        public Guid EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime DateHired { get; set; }
        public string DateHiredString => DateHired.ToString("MM/dd/yyyy");
        public DateTime BirthDate { get; set; }
        public string BirthDateString => BirthDate.ToString("MM/dd/yyyy");
        public decimal Salary { get; set; }
        public string SalaryString => Salary.ToString();
        public RecurrenceInterval Recurrence { get; set; }
        public string RecurrenceString => Recurrence.ToString();
        public string JobTitle { get; set; }
        public string Department { get; set; }
        public string Availability { get; set; }
    }
}
