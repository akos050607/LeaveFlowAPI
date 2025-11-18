using Microsoft.AspNetCore.Mvc;
using LeaveFlowAPI.Models;
using LeaveFlowAPI.Interfaces;

namespace LeaveFlowAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LeaveRequestsController : ControllerBase
    {
        private readonly ILeaveRequestRepository _repository;

        public LeaveRequestsController(ILeaveRequestRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<ActionResult<LeaveRequest>> CreateLeaveRequest(LeaveRequest newRequest)
        {
            if (newRequest.StartDate <= DateTime.UtcNow)
            {
                return BadRequest("The leaverequestdate can't be in the past.");
            }

            if (newRequest.EndDate <= newRequest.StartDate)
            {
                return BadRequest("The ending and starting date are not valid.");
            }

            newRequest.Status = "Pending";
            
            newRequest.Id = 0; 

            await _repository.AddAsync(newRequest);
            await _repository.SaveChangesAsync();

            return Created(string.Empty, newRequest);
        }
    }
}