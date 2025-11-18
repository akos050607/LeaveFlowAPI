using LeaveFlowAPI.Models;

namespace LeaveFlowAPI.Interfaces
{
    public interface IDepartmentRepository
    {
        // === READ ALL ===
        Task<IEnumerable<Department>> GetAllAsync();

        // === READ EMPLOYEES BY DEPARTMENT ID ===
        Task<IEnumerable<Employee>> GetEmployeesByDepartmentIdAsync(int departmentId);
        
        // === READ BY ID ===
        Task<Department?> GetByIdAsync(int id);
    }
}