using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission10_Hammond.Data;

namespace Mission10_Hammond.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BowlingController : ControllerBase
    {
        private BowlingLeagueContext _bowlingcontext;

        public BowlingController(BowlingLeagueContext temp)
        {
            _bowlingcontext = temp;
        }

        [HttpGet(Name = "GetBowlingLeague")]
        public IEnumerable<object> Get()
        {
            var bowlingList = _bowlingcontext.Bowlers
                .Join(_bowlingcontext.Teams,
                    bowler => bowler.TeamId,
                    team => team.TeamId,
                    (bowler, team) => new
                    {
                        bowler.BowlerId,
                        bowler.BowlerFirstName,
                        bowler.BowlerLastName,
                        bowler.BowlerMiddleInit,
                        bowler.BowlerAddress,
                        bowler.BowlerCity,
                        bowler.BowlerState,
                        bowler.BowlerZip,
                        bowler.BowlerPhoneNumber,
                        team.TeamName  // Include TeamName from Teams table
                    })
                .Where(joined => joined.TeamName == "Marlins" || joined.TeamName == "Sharks")
                .ToList();

            return (bowlingList);
        }
    }
}
