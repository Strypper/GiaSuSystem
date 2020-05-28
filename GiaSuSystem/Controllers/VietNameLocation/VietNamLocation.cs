using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GiaSuSystem.Database;
using GiaSuSystem.Models;
using GiaSuSystem.Models.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace GiaSuSystem.Controllers.VietNameLocation
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class VietNamLocation : ControllerBase
    {
        private AppDbContext _ctx;
        private UserManager<UserModel> _userManager;
        private SignInManager<UserModel> _signInManager;
        private readonly AppSettings _appsettings;

        public VietNamLocation(UserManager<UserModel> userManager,
                             SignInManager<UserModel> signInManager,
                             IOptions<AppSettings> appsettings,
                             AppDbContext ctx)
        {
            _ctx = ctx;
            _userManager = userManager;
            _signInManager = signInManager;
            _appsettings = appsettings.Value;
        }
        [HttpGet]
        public async Task<IActionResult> CitiesList()
        {
            var cities = await _ctx.Cities
                               .AsNoTracking().ToListAsync();
            return Ok(cities);
        }
        [HttpGet("{city}")]
        public async Task<IActionResult> DistrictsList(int city)
        {
            var districts = await _ctx.Districts
                                      .AsNoTracking()
                                      .Where(x => x.CityID == city)
                                      .ToListAsync();
            return Ok(districts);
        }
    }
}