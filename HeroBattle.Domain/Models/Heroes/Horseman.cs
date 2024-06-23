using HeroBattle.Domain.Enums;
using HeroBattle.Domain.Models.Common;

namespace HeroBattle.Domain.Models.Heroes
{
    public class Horseman : Hero
    {
        public Horseman()
        {
            Health = 150;
            MaxHealth = 150;
            Type = HeroType.Horseman;
        }

        public override void Attack(Hero defender)
        {
            switch (defender.Type)
            {
                case HeroType.Horseman:
                    defender.Health = 0;
                    break;
                case HeroType.Swordsman:
                    defender.Health = 0;
                    break;
                case HeroType.Archer:
                    defender.Health = 0;
                    break;
            }
        }
    }
}
