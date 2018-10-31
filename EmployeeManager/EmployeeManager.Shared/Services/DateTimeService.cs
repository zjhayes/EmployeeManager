using EmployeeManager.Shared.Services.Interfaces;
using System;

namespace EmployeeManager.Shared.Services
{
    class DateTimeService : IDateTimeService
    {
        public DateTime Now()
        {
            return DateTime.Now;
        }
    }
}
