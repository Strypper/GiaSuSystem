using GiaSuSystem.Models;
using GiaSuSystem.Models.Subjects;
using GiaSuSystem.Models.Subjects.ModifyFilters;
using GiaSuSystem.Models.User;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GiaSuSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class LoginRegister : ControllerBase
    {
        private UserManager<UserModel> _userManager;
        private SignInManager<UserModel> _signInManager;
        private readonly AppSettings _appsettings;

        public LoginRegister(UserManager<UserModel> userManager,
                             SignInManager<UserModel> signInManager,
                             IOptions<AppSettings> appsettings)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _appsettings = appsettings.Value;
        }
        [HttpPost]
        public async Task<IActionResult> Login([FromBody]Login u)
        {
            var user = await _userManager.FindByEmailAsync(u.Email);
            if (user != null)
            {
                var result = await _signInManager
                                    .PasswordSignInAsync(user, u.Pass, false, false);
                if (result.Succeeded)
                {
                    var role = await _userManager.GetRolesAsync(user);
                    IdentityOptions _options = new IdentityOptions();
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                        {
                            new Claim("UserID",user.Id.ToString()),
                            new Claim(_options.ClaimsIdentity.RoleClaimType, role.FirstOrDefault())
                        }),

                        Issuer = "null",
                        Audience = "null",
                        IssuedAt = DateTime.UtcNow,
                        NotBefore = DateTime.UtcNow,
                        Expires = DateTime.UtcNow.AddDays(1),
                        SigningCredentials =
                        new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appsettings.JWT_Secret)),
                        SecurityAlgorithms.HmacSha256Signature)
                    };
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                    var token = tokenHandler.WriteToken(securityToken);
                    return Ok(new { token });
                }
            }
            return NotFound("The user does not exist pls create Account");
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody]RegisterUser u)
        {
            School sc = new School();
            sc.SchoolName = u.SchoolName;
            sc.City = u.City;
            sc.District = u.SchoolDistrict;
            var user = new UserModel
            {
                UserName = u.UserName,
                PhoneNumber = u.PhoneNumber,
                Email = u.Email,
                Role = u.Role,
                DayOfBirth = u.DayOfBirth,
                Gender = u.Gender,
                Age = u.Age,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Address = u.Address,
                District = u.District,
                City = u.City,
                School = sc,
                ProfileImageUrl = u.ProfileImageUrl,
                Department = u.Department
            };
            var result = await _userManager.CreateAsync(user, u.Pass);
            await _userManager.AddToRoleAsync(user, u.Role);

            if (result.Succeeded)
            {
                return Ok("Your Profile Have set-up correctly !!");
            }
            return NotFound("There is something wrong");
        }
        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<Object> GetUserInfo()
        {
            string userId = User.Claims.First(c => c.Type == "UserID").Value;
            var user = await _userManager.FindByIdAsync(userId);
            return new
            {
                user.UserName,
                user.PhoneNumber,
                user.Email,
                user.Role,
                user.DayOfBirth,
                user.Gender,
                user.ProfileImageUrl,
                user.CoverImageUrl,
                user.Age,
                user.Address,
                user.District,
                user.City,
                user.School,
                user.Department,
            };
        }
    }
}
