using Microsoft.AspNetCore.Mvc;
using ResolveJa.Application.Api.Services.Interfaces;

namespace ResolveJa.Web.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpresasController : ControllerBase
    {
        private readonly IEmpresaApiService _empresaApiService;

        public EmpresasController(IEmpresaApiService empresaApiService)
        {
            _empresaApiService = empresaApiService;
        }

        [HttpGet]
        [Route("{url:string}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]      
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(
            [FromRoute] string url)
        {

        }
    }
}
