using System;
using System.ComponentModel.DataAnnotations;
using static EmployeeManager.Domain.Entities.Employee;

namespace EmployeeManager.Web.Models
{
    public class CreateEmployeeModel
    {
        [Display(Name = "Employee ID")]
        public Guid EmployeeId { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Date Hired")]
        public DateTime DateHired { get; set; }
        [Display(Name = "Date of Birth")]
        public DateTime BirthDate { get; set; }
        public decimal Salary { get; set; }
        public RecurrenceInterval Recurrence { get; set; }
        [Display(Name = "Job Title")]
        public string JobTitle { get; set; }
        public string Department { get; set; }
        public string Availability { get; set; }
    }
}