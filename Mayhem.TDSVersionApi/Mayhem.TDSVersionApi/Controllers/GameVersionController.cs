using Mayhem.Bl.Interfaces;
using Mayhem.Dal.Dto.Requests;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Mayhem.TDSVersionApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameVersionController : ControllerBase
    {
        private readonly IGameVersionService gameVersionService;

        public GameVersionController(IGameVersionService gameVersionService)
        {
            this.gameVersionService = gameVersionService;
        }

        [Route("GameVersion")]
        [HttpGet]
        [ProducesResponseType(typeof(TicketResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> GetTicket()
        {
            TicketResponse? response = await gameVersionService.GetVersionDetailsAsync();
            return CreatedAtAction(nameof(GetTicket), response);
        }
    }
}