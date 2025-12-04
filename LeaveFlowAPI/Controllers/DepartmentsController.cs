using Microsoft.AspNetCore.Mvc;
using LeaveFlowAPI.Models;
using LeaveFlowAPI.Interfaces;

namespace LeaveFlowAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentRepository _repository;

        public DepartmentsController(IDepartmentRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Department>>> GetDepartments()
        {
            var departments = await _repository.GetAllAsync();
            return Ok(departments);
        }

        [HttpGet("{id}/employees")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployeesForDepartment(int id)
        {
            var employees = await _repository.GetEmployeesByDepartmentIdAsync(id);
            return Ok(employees);
        }
    }
}