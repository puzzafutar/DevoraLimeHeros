namespace DevoraLimeHeros.Application.Factory.Tests
{
    [TestClass()]
    public class HeroFactoryTests
    {
        private readonly HeroFactory _heroFactory = new HeroFactory();
        
        [TestMethod()]
        public void GetHero_ArcheryTypeId5_ReturnsTrue()
        {
            var createdHero = _heroFactory.GetHero(Domain.HeroTypeEnum.Archery, 5);

            Assert.IsTrue(
                createdHero.Type == Domain.HeroTypeEnum.Archery && 
                createdHero.Id == 5 && 
                createdHero.HealtPoint == Constants.Hero.ArcherMaxHealth);
        }

        [TestMethod()]
        public void GetHero_SwordsmanTypeId5_ReturnsTrue()
        {
            var createdHero = _heroFactory.GetHero(Domain.HeroTypeEnum.Swordsman, 5);

            Assert.IsTrue(
                createdHero.Type == Domain.HeroTypeEnum.Swordsman &&
                createdHero.Id == 5 &&
                createdHero.HealtPoint == Constants.Hero.SwordsmanMaxHealth);
        }

        [TestMethod()]
        public void GetHero_RiderTypeId5_ReturnsTrue()
        {
            var createdHero = _heroFactory.GetHero(Domain.HeroTypeEnum.Rider, 5);

            Assert.IsTrue(
                createdHero.Type == Domain.HeroTypeEnum.Rider &&
                createdHero.Id == 5 &&
                createdHero.HealtPoint == Constants.Hero.RiderMaxHealth);
        }
    }
}