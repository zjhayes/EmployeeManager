using EmployeeManager.Shared.Services;
using System;
using static EmployeeManager.Domain.Entities.Employee;

namespace EmployeeManager.Shared.ViewModels
{
    public class EmployeeViewModel
    {
        public Guid EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string MiddleInitial {
            get
            {
                return MiddleName.Substring(0, 1);
            }
        }
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

        readonly HireDateService hireDateService = new HireDateService(new DateTimeService());
        public string Anniversary
        {
            get
            {
                if(hireDateService.IsAnniversary(this))
                {
                    return "Today is " + FirstName + "'s anniversary.";
                }
                else
                {
                    return DateHiredString;
                }
            }
        }
        public int YearsSinceHired => hireDateService.YearsSince(this);

        readonly DateOfBirthService dateOfBirthService = new DateOfBirthService(new DateTimeService());
        public bool IsBirthday => dateOfBirthService.IsAnniversary(this);
        public int Age => dateOfBirthService.YearsSince(this);
    }
}
