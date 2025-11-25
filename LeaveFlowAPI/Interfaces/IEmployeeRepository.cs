using LeaveFlowAPI.Models;

namespace LeaveFlowAPI.Interfaces
{
    public interface IEmployeeRepository
    {
        // === READ ===
        Task<IEnumerable<Employee>> GetEmployeesAsync();

        // === READ ID ===
        Task<Employee?> GetEmployeeByIdAsync(int id);

        // === READ LEAVE REQUESTS FOR EMPLOYEE ===
        Task<IEnumerable<LeaveRequest>> GetLeaveRequestsForEmployeeAsync(int employeeId);

        // === CREATE ===
        Task<Employee> CreateEmployeeAsync(Employee employee);
        // === UPDATE ===
        Task UpdateAsync(Employee employee);
        // === DELETE ===
        Task DeleteAsync(int id);
        
        // === EXISTS ===
        Task<bool> ExistsAsync(int id);

        // === SAVE CHANGES ===
        Task<int> SaveChangesAsync();
    }
}