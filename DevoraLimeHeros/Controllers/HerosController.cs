using Microsoft.AspNetCore.Mvc;
using DevoraLimeHeros.Application.Manager.Interface;
using DevoraLimeHeros.Domain;

namespace DevoraLimeHeros.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HerosController : ControllerBase
    {
        private readonly IArenaManager _arenaManager;
        
        public HerosController(IArenaManager arenaManager)
        {
            _arenaManager = arenaManager;
        }

        [HttpPost("generate")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<int> GenerateHeros(int heroCounter)
        {
            if (heroCounter < 2)
            {
                return BadRequest("Legal�bb 2 h�st kell gener�lni az ar�n�ba");
            }
            
            var result = _arenaManager.GenerateHeros(heroCounter);
            return Ok(result);
        }

        [HttpGet("fight")]
        [ProducesResponseType(typeof(List<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<string> Fight(int arenaId)
        {
            Arena? selectedArena = _arenaManager.GetArenaById(arenaId);
            if (selectedArena is null)
            {
                return BadRequest("Nincs ilyen azonos�t�val ar�na!");
            }

            var fightResult = _arenaManager.Fight(selectedArena);

            return Ok(fightResult);
        }


    }
}
