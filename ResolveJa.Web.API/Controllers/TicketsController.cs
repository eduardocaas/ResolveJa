using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;

namespace ResolveJa.Web.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketsController : ControllerBase
    {
        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        public IActionResult Create()
        {
            return Ok();
        }
    }
}
