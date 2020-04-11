using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EventOrganizer.Data;
using Microsoft.Extensions.Configuration;
using EventOrganizer.Models;
using Microsoft.EntityFrameworkCore;
using EventOrganizer.Utilities;
using Microsoft.AspNetCore.Authentication;

namespace EventOrganizer.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly EventOrganizerDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthController(EventOrganizerDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        // POST: api/users/Login
        /// <summary>
        /// Login as a user
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     Post /api/users/login
        ///     {
        ///         "email": "dinan@gmail.com",
        ///         "password": "myPass"
        ///     }
        ///
        /// </remarks>
        /// <param name="users">A user entity</param>
        /// <response code="201">Returns the created user entity.</response>
        /// <response code="400">The request could not be understood by the server due to malformed syntax</response>
        /// <response code="401">Email or Password is incorrect</response>
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [HttpPost("Login/Users")]
        public async Task<ActionResult<User>> Users(User users)
        {
            var result = await _context.User.FirstOrDefaultAsync(l => l.Email == users.Email);

            if (result == null)
            {
                return Unauthorized("The email or password is incorrect");
            }

            var validationStatus = AuthHelper.VerifyPassword(users.Password, result.Password);

            if (!validationStatus)
            {
                return Unauthorized("The email or password is incorrect");
            }

            result.LastLogin = DateTime.Now;
            result.IsActive = true;
            await _context.SaveChangesAsync();

            var filtered = new
            {
                result.Id,
                result.Name,
                result.Gender,
                result.PhoneNumber,
                result.Address,
                result.Email,
                result.LastLogin,
                result.IsActive,
                result.CreatedAt,
                result.UpdatedAt,
                token = AuthHelper.GenerateJwtToken(result.Id, _configuration["SecurityKey"]),
            };

            return Ok(filtered);
        }

        // GET: api/users/Logout
        /// <summary>
        /// Logout as a user
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     Post /api/users/logout
        ///
        /// </remarks>
        /// <param name="returnUrl">A url to redirect to</param>
        [HttpGet("Logout/Users")]
        public async Task<IActionResult> Users([FromQuery] string returnUrl)
        {
            await HttpContext.SignOutAsync();

            return Redirect(returnUrl);
        }
    }
}
