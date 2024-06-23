using HeroBattle.Domain.Models;
using HeroBattle.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace HeroBattle.Infrastructure.Repositories
{
    public class ArenaRepository : IArenaRepository
    {
        private readonly HeroBattleDbContext _context;
        private readonly ILogger<ArenaRepository> _logger;

        public ArenaRepository(HeroBattleDbContext context, ILogger<ArenaRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Arena> AddAsync(int numberOfHeroes)
        {
            try
            {
                var arena = new Arena()
                {
                    Id = Guid.NewGuid().ToString(),
                    IsFinished = false,
                    NumberOfHeroes = numberOfHeroes
                };

                _context.Arenas.Add(arena);
                await _context.SaveChangesAsync();

                return arena;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while adding a new arena.");
                throw;
            }
        }

        public async Task<Arena?> GetByIdAsync(string id)
        {
            try
            {
                return await _context.Arenas
                    .Include(x => x.History)
                    .SingleOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while getting the arena with Id: {id}.");
                throw;
            }
        }

        public async Task UpdateAsync(Arena arena)
        {
            try
            {
                _context.Arenas.Update(arena);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while updating the arena with Id {arena.Id}.");
                throw;
            }
        }
    }
}
