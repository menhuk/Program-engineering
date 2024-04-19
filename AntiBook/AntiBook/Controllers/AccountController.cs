using AntiBook.Dtos.Account;
using AntiBook.Interfaces;
using AntiBook.Models;
using AntiBook.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AntiBook.Controllers
{
    [Route("AntiBook/account")]
    [ApiController]
    public class AccountController:ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _tokenService;
        private readonly SignInManager<AppUser> _signinManager;
        public AccountController(UserManager<AppUser> userManager, ITokenService tokenService,SignInManager<AppUser> signinManager)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _signinManager = signinManager;
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == loginDto.Username.ToLower());
            if (user == null) { return Unauthorized("Invalid Username"); };
            var result = await _signinManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
            if (!result.Succeeded) { return Unauthorized("Username not found or password incorrect"); }
            return Ok(
                new NewUserDto
                {
                    Username = user.UserName,
                    Email = user.Email,
                    Token = _tokenService.CreateToken(user)
                }
                );
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            try
            {
                if(!ModelState.IsValid)
                    return BadRequest(ModelState);
                var appUser = new AppUser
                {
                    UserName = registerDto.Username,
                    Email = registerDto.Email,
                };
                var createdUser = await _userManager.CreateAsync(appUser,registerDto.Password);
                if(createdUser.Succeeded) 
                {
                    var roleResult = await _userManager.AddToRoleAsync(appUser, "User"); 
                    if(roleResult.Succeeded)
                    {
                        return Ok(new NewUserDto
                        {
                            Username = appUser.UserName,
                            Email = appUser.Email,
                            Token = _tokenService.CreateToken(appUser)
                        });
                    }
                    else
                    {
                        return StatusCode(500, roleResult.Errors);
                    }
                }
                else
                {
                    return StatusCode(500, createdUser.Errors);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}
