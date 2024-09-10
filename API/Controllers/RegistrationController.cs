using API.Data;
using API.Data.DTO;
using API.Models.Domain;
using API.Repository.Implimentation;
using API.Repository.Interface;
using Azure;
using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq.Expressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;

        private readonly ITokenRepository tokenRepository;
        public IApplicationLog ApplicationLog { get; }

        public RegistrationController(UserManager<IdentityUser> userManager, ITokenRepository tokenRepository, IApplicationLog ApplicationLog)
        {
            this.userManager = userManager;
            this.tokenRepository = tokenRepository;
            this.ApplicationLog = ApplicationLog;
        }

        [HttpPost]
        [Route("Login")]

        public async Task<IActionResult> Login([FromBody] LoginRequestDto request)
        {
            //var identityUser = await userManager.FindByEmailAsync(request.Email);
            try
            {
                var identityUser = await userManager.Users.FirstOrDefaultAsync(e => e.PhoneNumber == request.PhoneNumber);

            if (identityUser is not null)
            {
                var checkPassRes = await userManager.CheckPasswordAsync(identityUser, request.Password);

                var roles = await userManager.GetRolesAsync(identityUser);

                if (checkPassRes)
                {
                    //create Token
                    var jwtToken = tokenRepository.CreateJwtToken(identityUser, roles.ToList());
                    var response = new LoginResponseDto()
                    {
                        Email = identityUser?.Email,
                        Roles = roles.ToList(),
                        Token = jwtToken
                    };
                    return Ok(response);
                }
            }
            ModelState.AddModelError("", "Phone Number or Password is wrong");
        }
            catch (Exception ex) {
                var Error = new ApplicationLogs()
                {
                    FunctionName = "Login",
                    LineNumber = ex.StackTrace,
                    UserName = request.PhoneNumber,
                    Description = ex.Message
                };
                //Adding ApplicationLog
                await ApplicationLog.CreateAsync(Error);
            }


            return ValidationProblem(ModelState);
        }

        [HttpPost]
        [Route("Register")]
        //Route APi/Registration
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto request)
        {
            try { 
            var user = new IdentityUser
            {
                UserName = request?.Name.Trim(),
                Email = request?.Email.Trim(),
                PhoneNumber = request?.PhoneNumber.Trim()
            };
            var identityResult = await userManager.CreateAsync(user,request.Password);

            if (identityResult.Succeeded)
            {
                //add role
                if(request.Sarpanch)
                {
                    identityResult = await userManager.AddToRoleAsync(user, "Sarpanch");
                }
                else
                {
                    identityResult = await userManager.AddToRoleAsync(user, "People");
                }

                if (identityResult.Succeeded) 
                {
                    return Ok(user);
                }
                else
                {
                    if (identityResult.Errors.Any())
                    {
                        foreach (var Errors in identityResult.Errors)
                        {
                            ModelState.AddModelError("", Errors.Description);
                        }
                    }
                }
            }
            else
            {
                if(identityResult.Errors.Any())
                {
                    foreach (var Errors in identityResult.Errors)
                    {
                        ModelState.AddModelError("", Errors.Description);
                    }
                }
            }
            }
            catch (Exception ex) {
                var Error = new ApplicationLogs()
                {
                    FunctionName = "Register",
                    LineNumber = ex.StackTrace,
                    UserName = request.PhoneNumber,
                    Description = ex.Message
                };
                //Adding ApplicationLog
                await ApplicationLog.CreateAsync(Error);
            }

            return ValidationProblem(ModelState);

        }

       

    }
}
