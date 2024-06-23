using HeroBattle.Domain.Models;

namespace HeroBattle.Infrastructure.Repositories
{
    public interface IArenaRepository
    {
        Task<Arena> AddAsync(int numberOfHeroes);

        Task<Arena?> GetByIdAsync(string id);

        Task UpdateAsync(Arena arena);
    }
}
