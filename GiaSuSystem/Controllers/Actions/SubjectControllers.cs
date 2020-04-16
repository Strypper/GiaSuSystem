using GiaSuSystem.Models.Subjects;
using GiaSuSystem.Models.Subjects.ModifyFilters;
using GiaSuSystem.Models.User;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace GiaSuSystem.Models.Actions
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
    public class SubjectControllers : ControllerBase
    {
        private AppDbContext _ctx;
        private UserManager<UserModel> _userManager;
        public SubjectControllers(AppDbContext ctx, UserManager<UserModel> userManager) { _ctx = ctx; _userManager = userManager; }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IEnumerable<RequestSubject>> Requests()
        {
            var request = _ctx.RequestSubjects.AsNoTracking();
            return await request.ToListAsync();
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<int> NumberOfRecord() 
        {
            var count = _ctx.RequestSubjects
                            .AsNoTracking()
                            .CountAsync();
            return await count;
        }
        [AllowAnonymous]
        [HttpGet("{page}")]
        public async Task<IEnumerable<RequestPage>> RequestPage(int page)
        {
            page = page * 10;
            var request = _ctx.RequestSubjects.AsNoTracking()
                              .Select(x => new RequestPage()
            {
                RequestID = x.RequestID,
                ProfileUrlImage = x.Owner.ProfileImageUrl,
                Firstname = x.Owner.FirstName,
                Lastname = x.Owner.LastName,
                Price = x.Price,
                Sub = x.Subject.Name,
                Date = x.RequestDate,
                SchoolSubjectName = x.SchoolSubject.SchoolName
            }).OrderBy(x => x.Date).Skip(page).Take(10);
            return await request.ToListAsync();
        }
        [HttpGet("{id}")]
        public IActionResult RequestDetail(int id)
        {
            //Object type will return null, remember to include all of them
            var request = _ctx.RequestSubjects.AsNoTracking()
                        .Include(x => x.Students).Include(y => y.Owner)
                        .Include(z => z.Subject).Include(g => g.LocationAddress)
                        .Include(h => h.SchoolSubject)
                        .FirstOrDefault(z => z.RequestID == id);
            return Ok(request);
        }
        [HttpPost]
        public async Task<IActionResult> CreateRequest([FromBody]CreateRequest request)
        {
            string userId = User.Claims.First(c => c.Type == "UserID").Value;
            var user = await _userManager.FindByIdAsync(userId);
            _ctx.RequestSubjects.Add(new RequestSubject
            {
                Subject = request.Subject,
                Price = request.Price,
                Owner = user,
                RequestDate = DateTime.Now,
                LocationAddress = request.Location,
                Description = request.Description,
                SchoolSubject = request.SchoolSubject
            });
            await _ctx.SaveChangesAsync();
            return Ok("Your Subject successfully get to our system");
        }
    }
}
