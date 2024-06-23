using HeroBattle.Domain.Models;
using HeroBattle.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace HeroBattle.Infrastructure.Repositories
{
    public class ArenaRepository : IArenaRepository
    {
        private readonly HeroBattleDbContext _context;

        public ArenaRepository(HeroBattleDbContext context)
        {
            _context = context;
        }

        public async Task<Arena> AddAsync(int numberOfHeroes)
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

        public async Task<Arena?> GetByIdAsync(string id) => await _context.Arenas.Include(x => x.History).SingleOrDefaultAsync(x => x.Id == id);

        public async Task UpdateAsync(Arena arena)
        {
            var arenaToUpdate = await _context.Arenas.SingleOrDefaultAsync(x => x.Id == arena.Id);
            if (arenaToUpdate is not null)
            {
                arenaToUpdate.History = arena.History;
                arenaToUpdate.IsFinished = true;

                await _context.SaveChangesAsync();
            }
        }
    }
}
