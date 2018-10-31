using EmployeeManager.Shared.ViewModels;

namespace EmployeeManager.Shared.Services.Interfaces
{
    public interface IAnniversaryService
    {
        bool IsAnniversary(EmployeeViewModel employee);
        int YearsSince(EmployeeViewModel employee);
    }
}
