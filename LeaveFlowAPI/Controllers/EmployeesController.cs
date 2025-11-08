using Microsoft.AspNetCore.Mvc;

namespace LeaveFlowAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeesController : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<Employee>> GetEmployees()
    {           
        var employees = new List<Employee>
        {
            new Employee { Id = 1, Name = "Tóth János", Position = "Fejlesztő", HireDate = new DateTime(2023, 11, 15, 9, 0, 0, DateTimeKind.Utc), Salary = 7500000, Projects = new[] { "Projekt Armageddon", "Projekt Before" } },
            new Employee { Id = 2, Name = "Nagy Anna", Position = "Projektmenedzser" , HireDate = new DateTime(2023, 12, 1, 9, 0, 0, DateTimeKind.Utc), Salary = 9000000, Projects = new[] { "Projekt Before", "Projekt Next" } },
            new Employee { Id = 3, Name = "Kiss Géza", Position = "HR" , HireDate = new DateTime(2025, 1, 15, 9, 0, 0, DateTimeKind.Utc), Salary = 6000000, Projects = null }
        };
    
        return Ok(employees);
    }
}
