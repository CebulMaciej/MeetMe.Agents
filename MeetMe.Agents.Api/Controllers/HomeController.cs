using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MeetMe.Agents.Api.Controllers
{
    [ApiController]
    [Route("api")]
    public class HomeController : ControllerBase
    {

        [HttpGet("/ping")]
#pragma warning disable 1998
        public async Task<ActionResult> Ping()
#pragma warning restore 1998
        {
            return Ok($"Hello from MeetMe Agents Service");
        }
    }
}