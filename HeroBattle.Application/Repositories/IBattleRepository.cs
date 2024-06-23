using HeroBattle.Domain.Models;

namespace HeroBattle.Application.Repositories
{
    public interface IBattleRepository
    {
        Task Battle(Arena arena);
    }
}
