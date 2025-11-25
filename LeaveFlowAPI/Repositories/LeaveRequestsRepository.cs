using LeaveFlowAPI.Interfaces;
using LeaveFlowAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LeaveFlowAPI.Repositories
{
    public class LeaveRequestRepository : ILeaveRequestRepository
    {
        private readonly PresenceDbContext _context;

        public LeaveRequestRepository(PresenceDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(LeaveRequest request)
        {
            await _context.LeaveRequests.AddAsync(request);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<LeaveRequest?> GetByIdAsync(int id)
        {
            return await _context.LeaveRequests.FindAsync(id);
        }

        public async Task<IEnumerable<LeaveRequest>> GetAllAsync()
        {
            return await _context.LeaveRequests.ToListAsync();
        }
    }
}