using HeroBattle.Domain.Enums;
using HeroBattle.Domain.Models.Common;

namespace HeroBattle.Domain.Models.Heroes
{
    public class Swordsman : Hero
    {
        public Swordsman()
        {
            Health = 120;
            MaxHealth = 120;
            Type = HeroType.Swordsman;
        }

        public override void Attack(Hero defender)
        {
            switch (defender.Type)
            {
                case HeroType.Swordsman:
                case HeroType.Archer:
                    defender.Health = 0;
                    break;
            }
        }
    }
}
