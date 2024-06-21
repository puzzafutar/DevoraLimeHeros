using DevorLimeHeros.Application.Providers;
using DevoraLimeHeros.Application.Factory;
using DevoraLimeHeros.Domain;

namespace DevoraLimeHeros.Application.Service.Tests
{
    [TestClass()]
    public class HeroServiceTests
    {
        private readonly HeroFactory _heroFactory = new HeroFactory();
        private readonly HeroService _heroService = new HeroService(new RandomProvider());

        private const int HalfHealtPoint = 80;
        private const int RelaxHealtPoint = 10;

        #region Archery attack

        [TestMethod()]
        public void Archery_x_Swordman_Attack_ReturnsTrue()
        {
            Hero archaryAttackHero = _heroFactory.GetHero(HeroTypeEnum.Archery, 1);
            Hero swordsmanAttackedHero = _heroFactory.GetHero(HeroTypeEnum.Swordsman, 2);

            _heroService.ArcheryAttack(archaryAttackHero, swordsmanAttackedHero);

            Assert.IsTrue(swordsmanAttackedHero.HealtPoint == 0);
        }

        [TestMethod()]
        public void Archery_x_Archery_Attack_ReturnsTrue()
        {
            Hero archaryAttackHero = _heroFactory.GetHero(HeroTypeEnum.Archery, 1);
            Hero archaryAttackedHero = _heroFactory.GetHero(HeroTypeEnum.Archery, 2);

            _heroService.ArcheryAttack(archaryAttackHero, archaryAttackedHero);

            Assert.IsTrue(archaryAttackedHero.HealtPoint == 0);
        }

        #endregion

        #region Sowrdsman Attack

        [TestMethod()]
        public void Swordsman_x_Rider_Attack_ReturnsTrue()
        {
            Hero swordsmanAttackHero = _heroFactory.GetHero(HeroTypeEnum.Swordsman, 1);
            Hero riderAttackedHero = _heroFactory.GetHero(HeroTypeEnum.Rider, 2);

            _heroService.SwordsmanAttack(swordsmanAttackHero, riderAttackedHero);

            Assert.IsTrue(swordsmanAttackHero.HealtPoint == Constants.Hero.SwordsmanMaxHealth &&
                            riderAttackedHero.HealtPoint == Constants.Hero.RiderMaxHealth);
        }

        [TestMethod()]
        public void Swordsman_x_Swordsman_Attack_ReturnsTrue()
        {
            Hero swordsmanAttackHero = _heroFactory.GetHero(HeroTypeEnum.Swordsman, 1);
            Hero swordsmanAttackedHero = _heroFactory.GetHero(HeroTypeEnum.Swordsman, 1);

            _heroService.SwordsmanAttack(swordsmanAttackHero,swordsmanAttackedHero);

            Assert.IsTrue(swordsmanAttackedHero.HealtPoint == 0);
        }

        [TestMethod()]
        public void Swordsman_x_Archery_Attack_ReturnsTrue()
        {
            Hero swordsmanAttackHero = _heroFactory.GetHero(HeroTypeEnum.Swordsman, 1);
            Hero archaryAttackedHero = _heroFactory.GetHero(HeroTypeEnum.Archery, 2);

            _heroService.SwordsmanAttack(swordsmanAttackHero, archaryAttackedHero);

            Assert.IsTrue(archaryAttackedHero.HealtPoint == 0);
        }

        #endregion

        #region Rider attack

        [TestMethod()]
        public void Rider_x_Rider_Attack_RetursTrue()
        {
            Hero riderAttackHero = _heroFactory.GetHero(HeroTypeEnum.Rider, 1);
            Hero riderAttackedHero = _heroFactory.GetHero(HeroTypeEnum.Rider, 2);

            _heroService.RiderAttack(riderAttackHero, riderAttackedHero);

            Assert.IsTrue(riderAttackedHero.HealtPoint == 0);
        }

        [TestMethod()]
        public void Rider_x_Swordsman_Attack_RetursTrue()
        {
            Hero riderAttackHero = _heroFactory.GetHero(HeroTypeEnum.Rider, 1);
            Hero swordsmanAttackedHero = _heroFactory.GetHero(HeroTypeEnum.Swordsman, 2);

            _heroService.RiderAttack(riderAttackHero, swordsmanAttackedHero);

            Assert.IsTrue(riderAttackHero.HealtPoint == 0);
        }

        [TestMethod()]
        public void Rider_x_Archery_Attack_RetursTrue()
        {
            Hero riderAttackHero = _heroFactory.GetHero(HeroTypeEnum.Rider, 1);
            Hero archeryAttackedHero = _heroFactory.GetHero(HeroTypeEnum.Archery, 2);

            _heroService.RiderAttack(riderAttackHero, archeryAttackedHero);

            Assert.IsTrue(archeryAttackedHero.HealtPoint == 0);
        }

        #endregion

        #region Dead

        [TestMethod()]
        public void Dead_Rider_ReturnsTrue()
        {
            Hero riderHero = _heroFactory.GetHero(HeroTypeEnum.Rider, 1);
            _heroService.Dead(riderHero);
            Assert.IsTrue(riderHero.HealtPoint == 0);
        }

        [TestMethod()]
        public void Dead_Archery_ReturnsTrue()
        {
            Hero archeryHero = _heroFactory.GetHero(HeroTypeEnum.Archery, 1);
            _heroService.Dead(archeryHero);
            Assert.IsTrue(archeryHero.HealtPoint == 0);
        }

        [TestMethod()]
        public void Dead_Swordsman_ReturnsTrue()
        {
            Hero swordsmanHero = _heroFactory.GetHero(HeroTypeEnum.Swordsman, 1);
            _heroService.Dead(swordsmanHero);
            Assert.IsTrue(swordsmanHero.HealtPoint == 0);
        }

        #endregion

        #region Dead By Max HealtPoint

        [TestMethod()]
        public void DeadByMaxHealtPoint_Rider_ReturnsTrue()
        {
            Hero riderHero = _heroFactory.GetHero(HeroTypeEnum.Rider, 1);
            riderHero.HealtPoint = 20;
            _heroService.DeadByMaxHealtPoint(riderHero);
            Assert.IsTrue(riderHero.HealtPoint == 0);
        }

        [TestMethod()]
        public void DeadByMaxHealtPoint_Archery_ReturnsTrue()
        {
            Hero archeryHero = _heroFactory.GetHero(HeroTypeEnum.Archery, 1);
            archeryHero.HealtPoint = 20;
            _heroService.DeadByMaxHealtPoint(archeryHero);
            Assert.IsTrue(archeryHero.HealtPoint == 0);
        }

        [TestMethod()]
        public void DeadByMaxHealtPoint_Swordman_ReturnsTrue()
        {
            Hero swordsmanHero = _heroFactory.GetHero(HeroTypeEnum.Swordsman, 1);
            swordsmanHero.HealtPoint = 20;
            _heroService.DeadByMaxHealtPoint(swordsmanHero);
            Assert.IsTrue(swordsmanHero.HealtPoint == 0);
        }

        #endregion

        #region Relax

        [TestMethod()]
        public void Relax_Rider_ReturnsTrue()
        {
            Hero riderHero = _heroFactory.GetHero(HeroTypeEnum.Rider, 1);
            riderHero.HealtPoint = HalfHealtPoint;
            _heroService.Relax(riderHero);
            Assert.IsTrue(riderHero.HealtPoint == HalfHealtPoint + RelaxHealtPoint);
        }

        [TestMethod()]
        public void Relax_Archery_ReturnsTrue()
        {
            Hero riderHero = _heroFactory.GetHero(HeroTypeEnum.Archery, 1);
            riderHero.HealtPoint = HalfHealtPoint;
            _heroService.Relax(riderHero);
            Assert.IsTrue(riderHero.HealtPoint == HalfHealtPoint + RelaxHealtPoint);
        }

        [TestMethod()]
        public void Relax_Swordman_ReturnsTrue()
        {
            Hero riderHero = _heroFactory.GetHero(HeroTypeEnum.Swordsman, 1);
            riderHero.HealtPoint = HalfHealtPoint;
            _heroService.Relax(riderHero);
            Assert.IsTrue(riderHero.HealtPoint == HalfHealtPoint + RelaxHealtPoint);
        }

        #endregion
    }
}