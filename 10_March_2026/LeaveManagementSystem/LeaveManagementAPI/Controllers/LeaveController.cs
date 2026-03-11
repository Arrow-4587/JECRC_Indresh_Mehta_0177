using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using LeaveManagementAPI.Data;
using LeaveManagementAPI.Models;

namespace LeaveManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LeaveController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LeaveController(AppDbContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "Employee")]
        [HttpPost("apply")]
        public IActionResult ApplyLeave(LeaveRequest request)
        {
            request.Status = "Pending";

            _context.LeaveRequests.Add(request);
            _context.SaveChanges();

            return Ok("Leave Applied Successfully");
        }

        [Authorize(Roles = "Employee")]
        [HttpGet("my-leaves")]
        public IActionResult MyLeaves()
        {
            var userId = User.FindFirst("UserId")?.Value;

            var leaves = _context.LeaveRequests
                .Where(x => x.EmployeeId == int.Parse(userId!))
                .ToList();

            return Ok(leaves);
        }

        [Authorize(Roles = "Manager")]
        [HttpGet("all")]
        public IActionResult GetAllLeaves()
        {
            return Ok(_context.LeaveRequests.ToList());
        }

        [Authorize(Roles = "Manager")]
        [HttpPut("approve/{id}")]
        public IActionResult ApproveLeave(int id)
        {
            var leave = _context.LeaveRequests.Find(id);

            if (leave == null)
                return NotFound();

            leave.Status = "Approved";

            _context.SaveChanges();

            return Ok("Leave Approved");
        }

        [Authorize(Roles = "Manager")]
        [HttpPut("reject/{id}")]
        public IActionResult RejectLeave(int id)
        {
            var leave = _context.LeaveRequests.Find(id);

            if (leave == null)
                return NotFound();

            leave.Status = "Rejected";

            _context.SaveChanges();

            return Ok("Leave Rejected");
        }
    }
}