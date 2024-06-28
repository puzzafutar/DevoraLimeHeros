using Microsoft.AspNetCore.Mvc;
using DevoraLimeHeros.Application.Manager.Interface;

namespace DevoraLimeHeros.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HerosController : ControllerBase
    {
        private readonly IArenaManager _arenaManager;
        private readonly ILogger<HerosController> _logger;

        public HerosController(IArenaManager arenaManager, ILogger<HerosController> logger)
        {
            _arenaManager = arenaManager;
            _logger = logger;
        }

        [HttpPost("arena")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<int> GenerateHeros(int heroCounter)
        {
            if (heroCounter < 2)
            {
                return BadRequest("Legalább 2 hõst kell generálni az arénába");
            }
            
            var result = _arenaManager.GenerateHeros(heroCounter);
            return Ok(result);
        }

        [HttpGet("fight")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<string> Fight(int arenaId)
        {
            bool hasArena = _arenaManager.HasArenaByID(arenaId);
            
            if (!hasArena)
            {
                return BadRequest("Nincs ilyen azonosítóval aréna!");
            }

            var fightResult = _arenaManager.Fight(arenaId);

            return Ok(fightResult);
        }


    }
}
