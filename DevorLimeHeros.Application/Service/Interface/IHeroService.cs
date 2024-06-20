using DevoraLimeHeros.Domain;

namespace DevoraLimeHeros.Application.Service.Interface
{
    public interface IHeroService
    {
        void Relax(Hero hero);

        AttackResult Attack(Hero hero, Hero attackedHero);

        void Dead(Hero hero);
    }
}
