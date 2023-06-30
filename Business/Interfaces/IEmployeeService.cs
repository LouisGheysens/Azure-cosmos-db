using Data.Models;

namespace Business.Interfaces;
public interface IEmployeeService
{
    Task<IEnumerable<Employee>> GetAllEmployees();
    Task<Employee> GetById(string id);
    Task AddAsync(Employee employee);
    Task UpdateAsync(string id, Employee employee);
    Task DeleteAsync(string id);

}
