using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Opw.HttpExceptions;
using ResolveJa.Application.Api.InputModels;
using ResolveJa.Application.Api.Services.Interfaces;

namespace ResolveJa.Web.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketsController : ControllerBase
    {
        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        public IActionResult Create(
            [FromBody] TicketCreateInputModel inputModel,
            [FromServices] ITicketApiService ticketApiService)
        {
            try
            {
    
            }
            catch (Exception exception)
            {

            }
            catch (NotFoundException nfException)
            {

            }
        }
    }
}
