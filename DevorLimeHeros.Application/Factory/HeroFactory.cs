using DevoraLimeHeros.Application.Factory.Interface;
using DevoraLimeHeros.Domain;

namespace DevoraLimeHeros.Application.Factory
{
    public class HeroFactory : IHeroFactory
    {
        public Hero GetHero(HeroTypeEnum heroType, int id)
        {
            int maxHealtPoint = 0;

            switch (heroType)
            {
                case HeroTypeEnum.Archery:
                    maxHealtPoint = Constants.Hero.ArcherMaxHealth;
                    break;

                case HeroTypeEnum.Rider:
                    maxHealtPoint = Constants.Hero.RiderMaxHealth;
                    break;

                case HeroTypeEnum.Swordsman:
                    maxHealtPoint = Constants.Hero.SwordsmanMaxHealth;
                    break;
            }

            return new Hero(heroType,id,maxHealtPoint);
        }
    }
}
