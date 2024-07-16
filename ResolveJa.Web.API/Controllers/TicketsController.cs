using System;
using System.Net.Mime;
using Microsoft.AspNetCore.Http.Extensions;
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
        private readonly ITicketApiService _ticketApiService;

        public TicketsController(ITicketApiService ticketApiService)
        {
            _ticketApiService = ticketApiService;
        }

        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> Create(
            [FromBody] TicketCreateInputModel inputModel)
        {
            try
            {
                var id = await _ticketApiService.Create(inputModel);
                return NoContent();
            }
            catch (NotFoundException nfException)
            {
                return StatusCode(StatusCodes.Status404NotFound, new
                {
                    message = nfException.Message,
                    date = DateTime.Now.ToString("dd/MM/yyyy - H:mm")
                });
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    message = exception.Message,
                    date = DateTime.Now.ToString("dd/MM/yyyy - H:mm")
                });
            }
        }

        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> GetTickets(
            [FromQuery] string cpf, 
            [FromQuery] string urlEmpresa)
        {
            try
            {
                var tickets = await _ticketApiService.GetTickets(cpf, urlEmpresa);
                return Ok(tickets);
            }
            catch (NotFoundException nfException)
            {
                return StatusCode(StatusCodes.Status404NotFound, new
                {
                    message = nfException.Message,
                    date = DateTime.Now.ToString("dd/MM/yyyy - H:mm")
                });
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    message = exception.Message,
                    date = DateTime.Now.ToString("dd/MM/yyyy - H:mm")
                });
            }  
        }

        public async Task<IActionResult> GetTicket(
            [FromRoute] int id)
        {

        }
    }
}
