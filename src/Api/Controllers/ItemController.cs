using D2RDropCalc.Server.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using D2RDropCalc.Server.Models.DTOs.Shared;

namespace D2RDropCalc.Server.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;
        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet("Test")]
        [ProducesResponseType(typeof(bool), 200)]
        public async Task<IActionResult> Test([FromQuery]string name, [FromQuery]Difficulty difficulty, [FromQuery]int players, [FromQuery]int mf, [FromQuery]MonsterType monsterType)
        {
            return Ok(await _itemService.GenerateDropRates(name, difficulty, players, mf, monsterType));
        }
    }
}
