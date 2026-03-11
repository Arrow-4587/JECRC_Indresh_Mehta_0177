using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
namespace JwtRoleAuthAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // This endpoint is protected and can only be accessed by users with the "Manager" role
        [HttpGet("dashboard")]
        [Authorize(Roles = "User")]
        public IActionResult GetUserDashboard()
        {
            return Ok(new
            {
                message = "Welcome to the User Dashboard! Only users with the 'User' role can see this."
            });
        }
    }
}