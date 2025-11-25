using LeaveFlowAPI.Models;
namespace LeaveFlowAPI.Interfaces
{
    public interface ILeaveRequestRepository
    {
        // Egyelőre csak a létrehozás (POST) kell a Controllerhez
        Task AddAsync(LeaveRequest request);
        
        // A mentés mindig kell
        Task<int> SaveChangesAsync();

        // (Opcionális: felvehetjük a jövőre gondolva, pl. jóváhagyáshoz)
        Task<LeaveRequest?> GetByIdAsync(int id);
        Task<IEnumerable<LeaveRequest>> GetAllAsync();
    }
}