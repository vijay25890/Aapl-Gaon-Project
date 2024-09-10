using API.Data.DTO;
using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SarpanchController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        public SarpanchController(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }
        
        [HttpGet]
        [Route("get-sarpanch-users")]
        public async Task<ActionResult<List<IdentityUser>>> GetSarpanchUsers()
        {
            // Find the users with role sarpanch
            var users = await userManager.GetUsersInRoleAsync("Sarpanch");

            if (users == null || users.Count == 0)
                return NotFound(new { Message = "User not found" });

            return Ok(users);
        }

        [HttpDelete]
        [Route("delete-sarpanch-user")]
        public async Task<IActionResult> DeleteSarpanchUsers([FromBody] string Id)
        {
            // Find the user by Id
            var identityUser = await userManager.Users.FirstOrDefaultAsync(e => e.Id == Id);

            if (identityUser == null)
            {
                // If user not found, return NotFound result
                return NotFound(new { Message = "User not found" });
            }

            // Delete the user
            var result = await userManager.DeleteAsync(identityUser);

            if (result.Succeeded)
            {
                // Return success result
                return Ok(new { Message = "User deleted successfully" });
            }

            // If deletion failed, return bad request with error details
            return BadRequest(new { Errors = result.Errors });
        }

        [HttpPut]
        [Route("update-sarpanch-user/{id}")]
        //[Authorize(Roles = "Sarpanch")]
        public async Task<IActionResult> EditCategory([FromRoute] string id, [FromBody] getSarpanchDTO request)
        {
            // Convert DTO to Domain Model
            var identityUser = await userManager.Users.FirstOrDefaultAsync(u => u.Id == id);

            if (identityUser == null)
            {
                return NotFound(new { Message = "User not found" });
            }

            // Update user properties
            identityUser.PhoneNumber = request.PhoneNumber;
            identityUser.Email = request.Email;

            // Update the user in the database
            var result = await userManager.UpdateAsync(identityUser);

            if (result.Succeeded)
            {
                return Ok(new { Message = "User updated successfully" });
            }

            // If update failed, return bad request with error details
            return BadRequest(new { Errors = result.Errors });
        }

    }
}
