using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GiaSuSystem.Database;
using GiaSuSystem.Models.User;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GiaSuSystem.Controllers.College
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
    public class CollegeTutorControllers : ControllerBase
    {
        private AppDbContext _ctx;
        private UserManager<UserModel> _userManager;
        public CollegeTutorControllers(AppDbContext ctx, UserManager<UserModel> userManager) { _ctx = ctx; _userManager = userManager; }
        [AllowAnonymous]
        [HttpGet("{page}")]
        public async Task<IActionResult> RequestCollegeTutorsPage(int page)
        {
            page = page * 24;
            var result = from Tutor in _ctx.Users.AsNoTracking().OrderBy(x => x.SchoolID).Skip(page).Take(24)
                         join scName in _ctx.Schools on Tutor.SchoolID equals scName.SchoolID into RequestPage
                         from m in RequestPage.DefaultIfEmpty()
                         select new
                         {
                             TutorID = Tutor.Id,
                             TutorStudyGroup = Tutor.StudyGroupID,
                             TutorStudyField = Tutor.StudyFieldID,
                             ProfileUrlImage = Tutor.ProfileImageUrl,
                             Firstname = Tutor.FirstName,
                             Lastname = Tutor.LastName,
                             SchoolName = m.SchoolName,
                             SchoolLogoUrl = m.SchoolLogo
                         };
            return Ok(await result.AsNoTracking().ToListAsync());
        }
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<Object> RequestCollegeTutorDetail(int id)
        {
            var tutordetail = await _ctx.Users.AsNoTracking()
                        .FirstOrDefaultAsync(x => x.Id == id);
            var school = await _ctx.Schools.AsNoTracking()
                                      .FirstAsync(x => x.SchoolID == tutordetail.SchoolID);
            var studygroup = await _ctx.StudyGroups.AsNoTracking()
                          .FirstAsync(x => x.StudyGroupID == tutordetail.StudyGroupID);
            var studyfield = await _ctx.StudyFields.AsNoTracking()
                          .FirstAsync(x => x.StudyFieldID == tutordetail.StudyFieldID);
            var scd = await _ctx.Districts.AsNoTracking()
                          .FirstAsync(x => x.DistrictID == school.District);
            var scc = await _ctx.Cities.AsNoTracking()
                          .FirstAsync(x => x.CityID == school.City);
            string schooldistrict = scd.DistrictName;
            string schoolcity = scc.CityName;
            return new
            {
                tutordetail.FirstName,
                tutordetail.LastName,
                tutordetail.Age,
                tutordetail.Gender,
                tutordetail.DayOfBirth,
                tutordetail.UserDistrict,
                tutordetail.UserCity,
                tutordetail.UserAddress,
                studygroup.StudyGroupImage,
                studygroup.StudyGroupName,
                studyfield.StudyFieldName,
                schooldistrict,
                schoolcity
            };
        }
    }
}
