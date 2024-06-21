using DevoraLimeHeros.Application.Factory.Interface;
using DevoraLimeHeros.ApplicationTests;
using Microsoft.Extensions.DependencyInjection;

namespace DevoraLimeHeros.Domain.Tests
{
    [TestClass()]
    public class AttackResultTests : DITestBase
    {
        [TestMethod()]
        public void GetAfterAttackString_ReturnsTrue()
        {
            IHeroFactory heroFactory = ServiceProvider.GetService<IHeroFactory>();

            Hero archeryHero = heroFactory.GetHero(HeroTypeEnum.Archery, 1);
            Hero riderHero = heroFactory.GetHero(HeroTypeEnum.Archery, 2);

            AttackResult attackResult = new AttackResult(archeryHero, riderHero);

            Assert.IsTrue(attackResult.GetAfterAttackString().Length > 10);
        }

        [TestMethod()]
        public void GetBeforeAttackString_ReturnsTrue()
        {
            IHeroFactory heroFactory = ServiceProvider.GetService<IHeroFactory>();

            Hero archeryHero = heroFactory.GetHero(HeroTypeEnum.Archery, 1);
            Hero riderHero = heroFactory.GetHero(HeroTypeEnum.Archery, 2);

            AttackResult attackResult = new AttackResult(archeryHero, riderHero);

            Assert.IsTrue(attackResult.GetBeforeAttackString().Length > 10);
        }
    }
}