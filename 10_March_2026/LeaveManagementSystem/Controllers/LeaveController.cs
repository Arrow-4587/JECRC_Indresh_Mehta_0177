using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using LeaveManagementAPI.Data;
using LeaveManagementAPI.Models;
using System.Security.Claims;

namespace LeaveManagementAPI.Controllers
{
    [ApiController]
    [Route("api/leave")]
    public class LeaveController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LeaveController(AppDbContext context)
        {
            _context = context;
        }

        // APPLY LEAVE
        [Authorize(Roles = "Employee")]
        [HttpPost("apply")]
        public IActionResult ApplyLeave(LeaveRequest request)
        {
            var userId = User.FindFirst("UserId")?.Value;

            request.EmployeeId = int.Parse(userId);
            request.Status = "Pending";

            _context.LeaveRequests.Add(request);
            _context.SaveChanges();

            return Ok(request);
        }

        // VIEW MY LEAVES
        [Authorize(Roles = "Employee")]
        [HttpGet("my-leaves")]
        public IActionResult MyLeaves()
        {
            var userId = User.FindFirst("UserId")?.Value;

            var leaves = _context.LeaveRequests
                .Where(l => l.EmployeeId == int.Parse(userId))
                .ToList();

            return Ok(leaves);
        }

        // VIEW ALL LEAVES (MANAGER)
        [Authorize(Roles = "Manager")]
        [HttpGet("all")]
        public IActionResult GetAllLeaves()
        {
            return Ok(_context.LeaveRequests.ToList());
        }

        // APPROVE LEAVE
        [Authorize(Roles = "Manager")]
        [HttpPut("approve/{id}")]
        public IActionResult ApproveLeave(int id)
        {
            var leave = _context.LeaveRequests.Find(id);

            if (leave == null)
                return NotFound();

            leave.Status = "Approved";
            _context.SaveChanges();

            return Ok(leave);
        }

        // REJECT LEAVE
        [Authorize(Roles = "Manager")]
        [HttpPut("reject/{id}")]
        public IActionResult RejectLeave(int id)
        {
            var leave = _context.LeaveRequests.Find(id);

            if (leave == null)
                return NotFound();

            leave.Status = "Rejected";
            _context.SaveChanges();

            return Ok(leave);
        }
    }
}