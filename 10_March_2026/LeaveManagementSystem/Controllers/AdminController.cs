using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using LeaveManagementAPI.Data;

namespace LeaveManagementAPI.Controllers
{
    [ApiController]
    [Route("api/admin")]
    [Authorize(Roles = "Admin")]
    public class AdminController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AdminController(AppDbContext context)
        {
            _context = context;
        }

        // GET ALL EMPLOYEES
        [HttpGet("employees")]
        public IActionResult GetEmployees()
        {
            var employees = _context.Users
                .Where(u => u.Role == "Employee")
                .ToList();

            return Ok(employees);
        }

        // DELETE EMPLOYEE
        [HttpDelete("delete/{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            var user = _context.Users.Find(id);

            if (user == null)
                return NotFound();

            _context.Users.Remove(user);
            _context.SaveChanges();

            return Ok("Employee deleted");
        }
    }
}