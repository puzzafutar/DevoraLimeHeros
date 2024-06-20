using DevoraLimeHeros.Application.Factory.Interface;
using DevoraLimeHeros.Domain;

namespace DevoraLimeHeros.Application.Factory
{
    public class HeroFactory : IHeroFactory
    {
        public Hero GetHero(HeroTypeEnum heroType, int id)
        {
            Hero resultHero = new Hero();

            resultHero.Type = heroType;
            resultHero.Id = id;

            switch (heroType)
            {
                case HeroTypeEnum.Archery:
                    resultHero.MaxHealtPoint = Constants.Hero.ArcherMaxHealth;
                    break;

                case HeroTypeEnum.Rider:
                    resultHero.MaxHealtPoint = Constants.Hero.RiderMaxHealth;
                    break;

                case HeroTypeEnum.Swordsman:
                    resultHero.MaxHealtPoint = Constants.Hero.SwordsmanMaxHealth;
                    break;
            }

            resultHero.HealtPoint = resultHero.MaxHealtPoint;

            return resultHero;
        }
    }
}
