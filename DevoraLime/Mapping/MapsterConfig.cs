using HeroBattle.API.Responses;
using HeroBattle.Domain.Models;
using Mapster;

namespace HeroBattle.API.Mapping
{
    public static class MapsterConfig
    {
        public static void RegisterMapsterConfiguration(this IServiceCollection services)
        {
            TypeAdapterConfig<Arena, GetArenaHistoryResponse>
              .NewConfig()
              .Map(dest => dest.NumberOfRounds, src => src.History.Count)
              .Map(dest => dest.Rounds, src => src.History.Select(round => round.Info).ToList());
        }
    }
}
