using EmployeeManager.Shared.Services.Interfaces;
using EmployeeManager.Shared.ViewModels;

namespace EmployeeManager.Shared.Services
{
    public class DateOfBirthService : IAnniversaryService
    {
        private readonly IDateTimeService _dateTimeService;

        public DateOfBirthService(IDateTimeService dateTimeService)
        {
            _dateTimeService = dateTimeService;
        }

        public bool IsAnniversary(EmployeeViewModel employee)
        {
            return employee.BirthDate.DayOfYear == _dateTimeService.Now().DayOfYear;
        }

        public int YearsSince(EmployeeViewModel employee)
        {
            if (employee.BirthDate.DayOfYear <= _dateTimeService.Now().DayOfYear)
            {
                return _dateTimeService.Now().Year - employee.BirthDate.Year;
            }
            else
            {
                return _dateTimeService.Now().Year - employee.BirthDate.Year - 1;
            }
        }
    }
}
