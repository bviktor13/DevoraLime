using HeroBattle.API.Requests;
using HeroBattle.API.Responses;
using HeroBattle.Application.Repositories;
using HeroBattle.Infrastructure.Repositories;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace HeroBattle.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArenaController : ControllerBase
    {
        private readonly IArenaRepository _arenaRepository;
        private readonly IBattleRepository _battleRepository;

        public ArenaController(IArenaRepository arenaRepository, IBattleRepository battleRepository)
        {
            _arenaRepository = arenaRepository;
            _battleRepository = battleRepository;
        }

        [HttpPost]
        public async Task<ActionResult<CreateArenaResponse>> Create([FromBody] CreateArenaRequest request)
        {
            var arena = await _arenaRepository.AddAsync(request.NumberOfHeroes);

            var createArenaResponse = arena.Adapt<CreateArenaResponse>();

            return Ok(createArenaResponse);
        }

        [HttpGet]
        public async Task<ActionResult<GetArenaHistoryResponse>> Get([FromQuery] GetArenaHistoryRequest request)
        {
            var getArenaHistoryResponse = new GetArenaHistoryResponse();
            var arena = await _arenaRepository.GetByIdAsync(request.ArenaId);

            if (arena is null)
            {
                return NotFound();
            }

            if(arena.IsFinished)
            {
                getArenaHistoryResponse = arena.Adapt<GetArenaHistoryResponse>();
                return Ok(getArenaHistoryResponse);
            }

            await _battleRepository.Battle(arena);

            getArenaHistoryResponse = arena.Adapt<GetArenaHistoryResponse>();
            return Ok(getArenaHistoryResponse);
        }
    }
}
