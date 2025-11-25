using LeaveFlowAPI.Interfaces;
using LeaveFlowAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LeaveFlowAPI.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly PresenceDbContext _context;

        public DepartmentRepository(PresenceDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Department>> GetAllAsync()
        {
            // Itt van elrejtve a komplex Include logika!
            return await _context.Departments
                                 .Include(d => d.Manager)
                                 .Include(d => d.Employees)
                                 .ToListAsync();
        }

        public async Task<IEnumerable<Employee>> GetEmployeesByDepartmentIdAsync(int departmentId)
        {
            return await _context.Employees
                                 .Where(e => e.DepartmentId == departmentId)
                                 .ToListAsync();
        }

        public async Task<Department?> GetByIdAsync(int id)
        {
            return await _context.Departments
                                 .Include(d => d.Manager)
                                 .FirstOrDefaultAsync(d => d.Id == id);
        }
    }
}