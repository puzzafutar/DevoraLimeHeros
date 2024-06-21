
using DevoraLimeHeros.Application.Manager.Interface;
using DevoraLimeHeros.Domain;
using DevoraLimeHeros.ApplicationTests;
using Microsoft.Extensions.DependencyInjection;
using DevoraLimeHeros.Application.Factory.Interface;

namespace DevoraLimeHeros.Application.Manager.Tests
{
    [TestClass()]
    public class ArenaManagerTests : DITestBase
    {
        private const int HeroCounter = 2;

        [TestMethod()]
        public void GenerateHeros_ReturnsTrue()
        {
            var arenaManager = ServiceProvider.GetService<IArenaManager>();

            int arenId =  arenaManager.GenerateHeros(HeroCounter);
            
            Assert.IsTrue(arenaManager.GetArenaById(arenId).HeroList.Count == HeroCounter);
        }

        [TestMethod()]
        public void Select2DifferentHeros_ReturnsTrue()
        {
            var arenaManager = ServiceProvider.GetService<IArenaManager>();
            var heroFactory = ServiceProvider.GetService<IHeroFactory>();

            int arenId = arenaManager.GenerateHeros(HeroCounter);

            List<Hero> heroList = new List<Hero>()
            {
                heroFactory.GetHero(HeroTypeEnum.Archery,1),
                heroFactory.GetHero(HeroTypeEnum.Swordsman,2),
                heroFactory.GetHero(HeroTypeEnum.Rider,3)
            };

            List<Hero> selectedHeros = arenaManager.Select2DifferentAliveHero(heroList);

            Assert.IsTrue(selectedHeros.First()!=selectedHeros.Last());
        }
    }
}