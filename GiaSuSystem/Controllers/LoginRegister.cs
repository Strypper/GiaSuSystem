using GiaSuSystem.Database;
using GiaSuSystem.Models;
using GiaSuSystem.Models.Subjects;
using GiaSuSystem.Models.Subjects.ModifyFilters;
using GiaSuSystem.Models.User;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private AppDbContext _ctx;
        private UserManager<UserModel> _userManager;
        private SignInManager<UserModel> _signInManager;
        private readonly AppSettings _appsettings;

        public LoginRegister(UserManager<UserModel> userManager,
                             SignInManager<UserModel> signInManager,
                             IOptions<AppSettings> appsettings,
                             AppDbContext ctx)
        {
            _ctx = ctx;
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
            School _Sc = new School();
            if (u.SchoolID.HasValue)
            {
                if(_ctx.Schools.AsNoTracking().FirstOrDefault(s => s.SchoolID == u.SchoolID) is School sc)
                {
                    _Sc.SchoolID = sc.SchoolID;
                }
            }
            else
            {
                _Sc.SchoolName = u.SchoolName;
                _Sc.City = u.SchoolCity;
                _Sc.District = u.SchoolDistrict;
                _Sc.SchoolAddress = u.SchoolAddress;
                _ctx.Schools.Add(_Sc);
                await _ctx.SaveChangesAsync();
            }

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
                UserAddress = u.Address,
                UserDistrict = u.District,
                UserCity = u.City,
                ProfileImageUrl = u.ProfileImageUrl,
                SchoolID = _Sc.SchoolID,
                StudyGroupID = u.StudyGroup,
                StudyFieldID = u.StudyField
            };
            var result = await _userManager.CreateAsync(user, u.Pass);
            await _userManager.AddToRoleAsync(user, u.Role);

            if (result.Succeeded)
            {
                return Ok("Your Profile Have set-up correctly !!");
            }
            return NotFound("There is something wrong, The Email or UserName must be conflict with someone else");
        }
        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<Object> GetUserInfo()
        {
            string userId = User.Claims.First(c => c.Type == "UserID").Value;
            var user = await _userManager.FindByIdAsync(userId);
            var SchoolInfo = await _ctx.Schools.AsNoTracking().FirstOrDefaultAsync(z => z.SchoolID == user.SchoolID);
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
                user.UserAddress,
                user.UserDistrict,
                user.UserCity,
                user.UserSubjectRequests,
                SchoolInfo.SchoolID,
                SchoolInfo.SchoolName,
                SchoolInfo.SchoolAddress,
                SchoolInfo.SchoolLogo
            };
        }
    }
}
