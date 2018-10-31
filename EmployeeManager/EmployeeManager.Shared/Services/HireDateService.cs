using EmployeeManager.Shared.Services.Interfaces;
using EmployeeManager.Shared.ViewModels;

namespace EmployeeManager.Shared.Services
{
    public class HireDateService : IAnniversaryService
    {
        private readonly IDateTimeService _dateTimeService;

        public HireDateService(IDateTimeService dateTimeService)
        {
            _dateTimeService = dateTimeService;
        }

        public bool IsAnniversary(EmployeeViewModel employee)
        {
            return employee.DateHired.DayOfYear == _dateTimeService.Now().DayOfYear;
        }

        public int YearsSince(EmployeeViewModel employee)
        {
            if(employee.DateHired.DayOfYear <= _dateTimeService.Now().DayOfYear)
            {
                return _dateTimeService.Now().Year - employee.DateHired.Year;
            }
            else
            {
                return _dateTimeService.Now().Year - employee.DateHired.Year - 1;
            }
        }
    }
}
