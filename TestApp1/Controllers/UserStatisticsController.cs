using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;
using TestApp1.Domain;
using TestApp1.Domain.Entity;
using TestApp1.Service;

namespace TestApp1.Controllers
{
    [ApiController]
    [Route("report")]
    public class UserStatisticsController : ControllerBase
    {
        private readonly ILogger<UserStatisticsController> _logger;
        public UserStatisticsController(ILogger<UserStatisticsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("info")]
        public async Task<ActionResult<UserStatistics>> GetAsync()
        {
            //DateTime dtStart = DateTime.Now;
            UserStatistics use = HttpContext.Session.Get<UserStatistics>("use");
            if (use == null)
            {
                using (var db = new UserManagmentDbContext())
                {
                    Result result = new Result();
                    use = new UserStatistics();
                    use.Query = Guid.NewGuid();

                    while (use.Percent < 100)
                    {
                        await Task.Delay(Config.RequestTime / 100);
                        use.Percent++;
                    }

                    result.user_id = db.UserStatistic.Select(c => c.IdentityUser).FirstOrDefault();
                    result.count_sign_in = db.UserStatistic.Where(c => c.IdentityUser == result.user_id).Select(c => c.PeriodFrom).Count();

                    use.Result = result;

                    HttpContext.Session.Set<UserStatistics>("use", use);

                    return use;
                }
            }
            else return use;
        }

        [HttpPost]
        [Route("user_statistics")]
        public async Task<ActionResult> PostAsync()
        {
            UserStatistic us = new UserStatistic();
            var guid = HttpContext.Session.Get<Guid>("guid");
            if (guid == Guid.Empty)
            {
                guid = Guid.NewGuid();
                HttpContext.Session.Set<Guid>("guid", guid);
            }
                    
            await using (var db = new UserManagmentDbContext())
            {
                db.UserStatistic.Add(us = new UserStatistic
                {
                    IdentityUser = guid,
                    PeriodFrom = new DateTime(2022, 04, 25, 11, 00, 00),
                    PeriodTo = new DateTime(2022, 04, 25, 12, 00, 00),
                });
                db.SaveChanges();
            }

            return Ok(us);
        }
    }
}