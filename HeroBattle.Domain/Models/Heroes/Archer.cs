using HeroBattle.Domain.Enums;
using HeroBattle.Domain.Models.Common;

namespace HeroBattle.Domain.Models.Heroes
{
    public class Archer : Hero
    {
        private readonly Random _random;

        public Archer(Random random)
        {
            Health = 100;
            MaxHealth = 100;
            Type = HeroType.Archer;
            _random = random;
        }

        public override void Attack(Hero defender)
        {
            Random rand = new Random();
            switch (defender.Type)
            {
                case HeroType.Horseman:
                    if (_random.NextDouble() < 0.4)
                        defender.Health = 0;
                    break;
                case HeroType.Swordsman:
                case HeroType.Archer:
                    defender.Health = 0;
                    break;
            }
        }
    }
}
