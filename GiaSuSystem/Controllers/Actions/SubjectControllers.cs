using GiaSuSystem.Database;
using GiaSuSystem.Models.Location;
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
        public async Task<IActionResult> RequestPage(int page)
        {
            page = page * 10;
            var result = from Subject in _ctx.RequestSubjects.AsNoTracking().OrderBy(x => x.RequestDate).Skip(page).Take(10)
                         join scName in _ctx.Schools on Subject.Subject.SchoolID equals scName.SchoolID into RequestPage
                         from m in RequestPage.DefaultIfEmpty()
                         select new
                         {
                             RequestID = Subject.RequestID,
                             ProfileUrlImage = Subject.Owner.ProfileImageUrl,
                             Firstname = Subject.Owner.FirstName,
                             Lastname = Subject.Owner.LastName,
                             Price = Subject.Price,
                             Sub = Subject.Subject.Name,
                             Date = Subject.RequestDate,
                             SchoolName = m.SchoolName
                         };
            return Ok(await result.AsNoTracking().ToListAsync());
        }
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<Object> RequestDetail(int id)
        {
            //Object type will return null, remember to include all of them
            var request = await _ctx.RequestSubjects.AsNoTracking()
                        .Include(x => x.Students)
                        .Include(z => z.Subject)
                        .FirstOrDefaultAsync(z => z.RequestID == id);
            var schoolsubject = await _ctx.Schools.AsNoTracking()
                                      .FirstAsync(x => x.SchoolID == request.Subject.SchoolID);
            var studygroup = await _ctx.StudyGroups.AsNoTracking()
                          .FirstAsync(x => x.StudyGroupID == request.Subject.StudyGroupID);
            var studyfield = await _ctx.StudyFields.AsNoTracking()
                          .FirstAsync(x => x.StudyFieldID == request.Subject.StudyFieldID);
            var learningdistrict = await _ctx.Districts.AsNoTracking()
                          .FirstAsync(x => x.DistrictID == request.LearningDistrict);
            var learningcity = await _ctx.Cities.AsNoTracking()
                          .FirstAsync(x => x.CityID == request.LearningCity);
            var scd = await _ctx.Districts.AsNoTracking()
                          .FirstAsync(x => x.DistrictID == schoolsubject.District);
            var scc = await _ctx.Cities.AsNoTracking()
                          .FirstAsync(x => x.CityID == schoolsubject.City);
            string schooldistrict = scd.DistrictName;
            string schoolcity = scc.CityName;
            return new
            {
                request.Subject.Name,
                studygroup.StudyGroupName,
                studyfield.StudyFieldName,
                request.Description,
                request.Price,
                request.LearningAddress,
                learningdistrict.DistrictName,
                learningcity.CityName,
                request.Students,
                request.HomeWork,
                request.Presentation,
                request.Laboratory,
                request.RequestDate,
                request.Subject.Teacher,
                schoolsubject.SchoolName,
                schoolsubject.SchoolLogo,
                schoolsubject.SchoolAddress,
                schooldistrict,schoolcity
            };
        }
        [HttpPost]
        public async Task<IActionResult> CreateRequest([FromBody]CreateRequest request)
        {
            string userId = User.Claims.First(c => c.Type == "UserID").Value;
            var user = await _userManager.FindByIdAsync(userId);
            School _Sc = new School();
            Subject _Sj = new Subject();
            _Sj.Name = request.SubjectName;
            _Sj.Teacher = request.SubjectTeacher;
            _Sj.StudyGroupID = request.StudyGroup;
            _Sj.StudyFieldID = request.StudyField;
            if (request.SchoolID.HasValue)
            {
                if (_ctx.Schools.AsNoTracking().FirstOrDefault(s => s.SchoolID == request.SchoolID) is School sc)
                {
                    _Sj.SchoolID = sc.SchoolID;
                }
            }
            else
            {
                _Sc.SchoolName = request.SchoolName;
                _Sc.SchoolAddress = request.SchoolAddress;
                _Sc.District = request.SchoolDistrict;
                _Sc.City = request.SchoolCity;
                _ctx.Schools.Add(_Sc);
                await _ctx.SaveChangesAsync();
                _Sj.SchoolID = _Sc.SchoolID;
            }
            _ctx.RequestSubjects.Add(new RequestSubject
            {
                Subject = _Sj,
                Price = request.Price,
                Owner = user,
                RequestDate = DateTime.Now,
                LearningAddress = request.LearningAddress,
                LearningDistrict = request.LearningDistrict,
                LearningCity = request.LearningCity,
                Description = request.Description,
                HomeWork = request.HomeWork,
                Presentation = request.Presentation,
                Laboratory = request.Laboratory,
                RequestSchedules = request.WeekDays
            });
            await _ctx.SaveChangesAsync();
            return Ok("Your Subject successfully get to our system");
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> StudyGroupList()
        {
            var studygroup = await _ctx.StudyGroups
                               .AsNoTracking().ToListAsync();
            return Ok(studygroup);
        }
        [AllowAnonymous]
        [HttpGet("{group}")]
        public async Task<IActionResult> StudyFieldList(int group)
        {
            var studyFields = await _ctx.StudyFields
                                      .AsNoTracking()
                                      .Where(x => x.StudyGroupID == group)
                                      .ToListAsync();
            return Ok(studyFields);
        }
        [AllowAnonymous]
        [HttpGet("{district}")]
        public async Task<IActionResult> SchoolList(int district)
        {
            var schools = await _ctx.Schools
                                      .AsNoTracking()
                                      .Where(x => x.District == district)
                                      .ToListAsync();
            return Ok(schools);
        }
    }
}
