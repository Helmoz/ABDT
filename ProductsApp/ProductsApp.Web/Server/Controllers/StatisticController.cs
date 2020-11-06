using Microsoft.AspNetCore.Mvc;
using ProductsApp.Core.Channels;
using ProductsApp.Core.Entities;
using ProductsApp.Core.Entities.Enums;
using ProductsApp.Core.Queries;
using Reinforced.Tecture;
using Reinforced.Tecture.Aspects.Orm.Queries;

namespace ProductsApp.Web.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticController : ControllerBase
    {
        private ITecture Tecture { get; }
        
        public StatisticController(ITecture tecture)
        {
            Tecture = tecture;
        }
        public IActionResult Get(StatisticType statisticType)
        {
            var statistic = Tecture.From<Db>().Get<UserSession>().GetIntervalStatistic(statisticType);
            var s = new StatisticResponse(statistic);
            return Ok(s);
        }
    }
}