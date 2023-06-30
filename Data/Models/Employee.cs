using Newtonsoft.Json;

namespace Data.Models;
public class Employee
{
    public int Id { get; set; }

    public string EmployeeName { get; set; }

    public string Department { get; set; }

    public int Salary { get; set; }
}
