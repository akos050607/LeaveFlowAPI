using LeaveFlowAPI.Interfaces;
using LeaveFlowAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LeaveFlowAPI.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly PresenceDbContext _context;

        public EmployeeRepository(PresenceDbContext context)
        {
            _context = context;
        }

        // === READ ===
        public async Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        // === READ ID ===
        public async Task<Employee?> GetEmployeeByIdAsync(int id)
        {
            return await _context.Employees.FindAsync(id);
        }
        // === READ LEAVE REQUESTS FOR EMPLOYEE ===
        public async Task<IEnumerable<LeaveRequest>> GetLeaveRequestsForEmployeeAsync(int employeeId)
        {
            return await _context.LeaveRequests
                                 .Where(lr => lr.EmployeeId == employeeId)
                                 .ToListAsync();
        }
        // === CREATE ===
        public async Task<Employee> CreateEmployeeAsync(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return employee;
        }
        // === UPDATE ===
        public Task UpdateAsync(Employee employee)
        {
            _context.Entry(employee).State = EntityState.Modified;
            return Task.CompletedTask;
        }

        // === DELETE ===
        public async Task DeleteAsync(int id)
        {
            var employeeToDelete = await GetEmployeeByIdAsync(id);
            if (employeeToDelete != null)
            {
                _context.Employees.Remove(employeeToDelete);
            }
        }
        // === EXISTS ===
        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Employees.AnyAsync(e => e.Id == id);
        }
        
        // === SAVE CHANGES ===
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}