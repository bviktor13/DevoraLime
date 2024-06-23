using HeroBattle.Domain.Enums;

namespace HeroBattle.Domain.Models.Common
{
    public abstract class Hero
    {
        public int Id { get; set; }

        public double Health { get; set; }

        public HeroType Type { get; set; }

        public double MaxHealth { get; protected set; }

        public abstract void Attack(Hero defender);

        public void Rest()
        {
            Health = Math.Min(Health + 10, MaxHealth);
        }
    }
}
