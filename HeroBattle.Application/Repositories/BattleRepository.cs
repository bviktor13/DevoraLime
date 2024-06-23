using HeroBattle.Domain.Models.Common;
using HeroBattle.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeroBattle.Infrastructure.Repositories;
using HeroBattle.Domain.Models.Heroes;

namespace HeroBattle.Application.Repositories
{
    public class BattleRepository : IBattleRepository
    {
        private readonly IArenaRepository _arenaRepository;

        public BattleRepository(IArenaRepository arenaRepository)
        {
                _arenaRepository = arenaRepository;
        }

        public async Task Battle(Arena arena)
        {
            var heroes = InitalizeHeroes(arena.NumberOfHeroes);

            Random rand = new Random();
            while (heroes.Count() > 1)
            {
                AttackRound(heroes, rand, arena);

                heroes = heroes.Where(h => h.Health > 0).ToList();
            }

            await _arenaRepository.UpdateAsync(arena);
        }

        private void AttackRound(List<Hero> heroes, Random rand, Arena arena)
        {
            var attacker = heroes[rand.Next(heroes.Count)];
            var defender = heroes[rand.Next(heroes.Count)];
            while (defender == attacker)
            {
                defender = heroes[rand.Next(heroes.Count)];
            }

            attacker.Attack(defender);

            if (defender.Health > 0)
            {
                defender.Health = (defender.Health / 2 < defender.MaxHealth / 4) ? 0 : defender.Health / 2;
            }
            if (attacker.Health > 0)
            {
                attacker.Health = (attacker.Health / 2 < attacker.MaxHealth / 4) ? 0 : attacker.Health / 2;
            }

            foreach (var hero in heroes.Where(h => h != attacker && h != defender))
            {
                hero.Rest();
            }

            arena.History.Add(new Round()
            {
                Info = $"{attacker.Type} ({attacker.Id}) attacked {defender.Type} ({defender.Id}). Attacker Health: {attacker.Health}, Defender Health: {defender.Health}",
            });
        }

        private List<Hero> InitalizeHeroes(int numberOfHeroes)
        {
            var heroes = new List<Hero>();
            var nextHeroId = 0;
            var random = new Random();

            for (int i = 0; i < numberOfHeroes; i++)
            {
                int heroType = random.Next(3);

                Hero hero = heroType switch
                {
                    0 => new Swordsman(),
                    1 => new Archer(random),
                    2 => new Horseman(),
                    _ => throw new InvalidOperationException()
                };

                hero.Id = nextHeroId++;
                heroes.Add(hero);
            }

            return heroes;
        }
    }
}
