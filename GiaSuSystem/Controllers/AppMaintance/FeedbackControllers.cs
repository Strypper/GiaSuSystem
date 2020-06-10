using GiaSuSystem.Database;
using GiaSuSystem.Models.AppMaintance;
using GiaSuSystem.Models.User;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiaSuSystem.Controllers.AppMaintance
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
    public class FeedbackControllers : ControllerBase
    {
        private AppDbContext _ctx;
        private UserManager<UserModel> _userManager;
        public FeedbackControllers(AppDbContext ctx, UserManager<UserModel> userManager) { _ctx = ctx; _userManager = userManager; }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IEnumerable<FeedbackHub>> Feedbacks()
        {
            var request = _ctx.FeedbackHubs.Include(x => x.Owner).AsNoTracking();
            return await request.ToListAsync();
        }
        public async Task<IActionResult> CreateFeedBack([FromBody]FeedbackHub feedback)
        {
            string userId = User.Claims.First(c => c.Type == "UserID").Value;
            var user = await _userManager.FindByIdAsync(userId);
            _ctx.FeedbackHubs.Add(new FeedbackHub 
            {
                Title = feedback.Title,
                Detail = feedback.Detail,
                Platform = feedback.Platform,
                Owner = user,
                TimeUpload = DateTime.Now
            });
            await _ctx.SaveChangesAsync();
            return Ok("Thanks you for your feedback we will fix it right away");
        }
    }
}
