using Microsoft.AspNetCore.Mvc;
using LeaveFlowAPI.Models;
using LeaveFlowAPI.Interfaces;

namespace LeaveFlowAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _repository;

        public EmployeesController(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            var employees = await _repository.GetEmployeesAsync();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployeeById(int id)
        {
            var employee = await _repository.GetEmployeeByIdAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> CreateEmployee(Employee employee)
        {
            await _repository.CreateEmployeeAsync(employee);
            await _repository.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEmployeeById), new { id = employee.Id }, employee);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, Employee employee)
        {
            if (id != employee.Id)
            {
                return BadRequest("Az URL-ben lévő ID nem egyezik a testben lévő ID-vel.");
            }

            if (!await _repository.ExistsAsync(id))
            {
                return NotFound();
            }

            await _repository.UpdateAsync(employee);
            await _repository.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            if (!await _repository.ExistsAsync(id))
            {
                return NotFound();
            }

            await _repository.DeleteAsync(id);
            await _repository.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("{employeeId}/leaverequests")]
        public async Task<ActionResult<IEnumerable<LeaveRequest>>> GetLeaveRequestsForEmployee(int employeeId)
        {
            if (!await _repository.ExistsAsync(employeeId))
            {
                return NotFound("Alkalmazott nem található.");
            }

            var requests = await _repository.GetLeaveRequestsForEmployeeAsync(employeeId);
            return Ok(requests);
        }
    }
}