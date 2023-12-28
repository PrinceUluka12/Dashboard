using Dashboard.Server.Models;

namespace Dashboard.Server.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<bool> PostToDb(List<EmployeeDataDto> data);
        Task<List<EmployeesData>> GetAll();   
    }
}
