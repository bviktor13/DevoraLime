using HeroBattle.Domain.Models.Common;
using HeroBattle.Domain.Models.Heroes;
using Moq;
using System.Collections;

namespace HeroBattle.Tests.UnitTests
{
    public class HeroTests
    {
        private readonly Random _random = new Random();

        [Theory]
        [ClassData(typeof(AttackTestData))]
        public void Hero_Attacks_Hero(Hero attacker, Hero defender, double expectedDefenderHealth)
        {
            // Act
            attacker.Attack(defender);

            // Assert
            Assert.Equal(expectedDefenderHealth, defender.Health);
        }

        [Theory]
        [InlineData(0.3, 0)]
        [InlineData(0.4, 150)]
        [InlineData(0.41, 150)]
        public void Archer_Attacks_Horseman(double rand, double expectedDefenderHealth)
        {
            // Arrange
            var randMock = new Mock<Random>();
            randMock.Setup(r => r.NextDouble()).Returns(rand);

            var archer = new Archer(randMock.Object);
            var horseman = new Horseman();

            // Act
            archer.Attack(horseman);

            // Assert
            Assert.Equal(expectedDefenderHealth, horseman.Health);
        }

        [Theory]
        [ClassData(typeof(IncreaseHealthTestData))]
        public void Rest_Increases_Health_By_10(Hero hero, int initialHealth, int expectedHealth)
        {
            // Arrange
            hero.Health = initialHealth;

            // Act
            hero.Rest();

            // Assert
            Assert.Equal(expectedHealth, hero.Health);
        }

        [Theory]
        [ClassData(typeof(MaxHealthTestData))]
        public void Rest_Does_Not_Exceed_Max_Health(Hero hero, int initialHealth, int expectedHealth)
        {
            // Arrange
            hero.Health = initialHealth;

            // Act
            hero.Rest();

            // Assert
            Assert.Equal(expectedHealth, hero.Health);
        }
    }

    /// <summary>
    /// Contains all possibilities except Archer attacks Horseman
    /// </summary>
    public class AttackTestData : IEnumerable<object[]>
    { 
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { new Archer(new Random()), new Archer(new Random()), 0 };
            yield return new object[] { new Archer(new Random()), new Swordsman(), 0 };
            yield return new object[] { new Swordsman(), new Swordsman(), 0 };
            yield return new object[] { new Swordsman(), new Archer(new Random()), 0 };
            yield return new object[] { new Swordsman(), new Horseman(), 150 };
            yield return new object[] { new Horseman(), new Horseman(), 0 };
            yield return new object[] { new Horseman(), new Archer(new Random()), 0 };
            yield return new object[] { new Horseman(), new Swordsman(), 0 };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class IncreaseHealthTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { new Archer(new Random()), 50, 60 }; // Initial health, expected health after rest
            yield return new object[] { new Swordsman(), 50, 60 };
            yield return new object[] { new Horseman(), 50, 60 };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class MaxHealthTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { new Archer(new Random()), 95, 100 }; // Initial health, expected health after rest
            yield return new object[] { new Swordsman(), 115, 120 };
            yield return new object[] { new Horseman(), 145, 150 };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
