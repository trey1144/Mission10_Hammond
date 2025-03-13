using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission10_Hammond.Data;

namespace Mission10_Hammond.Controllers
{
    [Route("[controller]")]
    [ApiController]

    // BowlingController class
    public class BowlingController : ControllerBase
    {
        // Private variable _bowlingcontext
        private BowlingLeagueContext _bowlingcontext;

        // Constructor for BowlingController
        public BowlingController(BowlingLeagueContext temp)
        {
            _bowlingcontext = temp;
        }

        // GET: BowlingController
        [HttpGet(Name = "GetBowlingLeague")]
        public IEnumerable<object> Get()
        {
            // Create a list of bowlers from the Bowlers table
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

            // Return the list of bowlers
            return (bowlingList);
        }
    }
}
