using DevoraLimeHeros.Domain;

namespace DevoraLimeHeros.Application.Factory.Interface
{
    public interface IHeroFactory
    {
        Hero GetHero(HeroTypeEnum heroType, int id);
    }
}
