using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
namespace JwtRoleAuthAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        // This endpoint is protected and can only be accessed by users with the "Manager" role
        [HttpGet("dashboard")]
        [Authorize(Roles = "Manager")]
        public IActionResult GetManagerDashboard()
        {
            return Ok(new
            {
                message = "Welcome to the Manager Dashboard! Only users with the 'Manager' role can see this."
            });
        }
                [HttpGet("reports")]
        [Authorize(Roles = "Admin,Manager")]
        public IActionResult GetManagerReports()
        {
            return Ok(new
            {
                message = "Welcome to the Manager Reports! Only users with the 'Admin' or 'Manager' role can see this."
            });
        }
    }
}