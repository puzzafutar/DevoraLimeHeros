using DevoraLimeHeros.Domain;
using DevoraLimeHeros.Application.Service.Interface;
using DevoraLimeHeros.Application.Provider.Interface;

namespace DevoraLimeHeros.Application.Service
{
    public class HeroService : IHeroService
    {
        private readonly IRandomProvider _randomProvider;
        
        public HeroService(IRandomProvider randomProvider)
        {
            _randomProvider = randomProvider;
        }

        public void Relax(Hero hero)
        {
            if (hero.HealtPoint > 0)
            {
                int lossOfVitality = hero.MaxHealtPoint - hero.HealtPoint;

                if (lossOfVitality >= 10)
                {
                    hero.HealtPoint += 10;
                }
                else
                {
                    hero.HealtPoint = hero.MaxHealtPoint;
                }
            }

            if (hero.HealtPoint > hero.MaxHealtPoint)
            {
                throw new Exception("Az életerő nem mehet a maximum életerő fölé!");
            }
        }

        public AttackResult Attack(Hero attackHero, Hero attackedHero)
        {
            //A harcban résztvevő hősök életereje a felére csökken,
            attackHero.HealtPoint = attackHero.HealtPoint / Constants.Hero.HalfValue;
            attackedHero.HealtPoint = attackedHero.HealtPoint / Constants.Hero.HalfValue;

            //ha ez kisebb, mint a kezdeti életerő negyede, akkor meghalnak.
            DeadByMaxHealtPoint(attackHero);
            DeadByMaxHealtPoint(attackedHero);

            if (attackHero.HealtPoint != 0 || attackedHero.HealtPoint != 0)
            {
                switch (attackHero.Type)
                {
                    case HeroTypeEnum.Archery:
                        ArcheryAttack(attackHero, attackedHero);
                        break;

                    case HeroTypeEnum.Rider:
                        RiderAttack(attackHero, attackedHero);
                        break;

                    case HeroTypeEnum.Swordsman:
                        SwordsmanAttack(attackHero, attackedHero);
                        break;
                }
            }

            return new AttackResult(attackHero, attackedHero);
        }

        public void Dead(Hero hero)
        {
            hero.HealtPoint = 0;
        }

        public void DeadByMaxHealtPoint(Hero hero)
        {
            if (hero.HealtPoint < (hero.MaxHealtPoint / Constants.Hero.QuaterValue))
            {
                Dead(hero);
            }
        }

        public void ArcheryAttack(Hero archeryHero, Hero attackedHero)
        {
            switch (attackedHero.Type)
            {
                case HeroTypeEnum.Rider:
                    if (_randomProvider.GetDoubleValue() < 0.4)
                        Dead(attackedHero);
                    break;

                case HeroTypeEnum.Archery:
                case HeroTypeEnum.Swordsman:
                    Dead(attackedHero);
                    break;
            }
        }

        public void SwordsmanAttack(Hero swordsManHero, Hero attackedHero)
        {
            switch (attackedHero.Type)
            {
                case HeroTypeEnum.Archery:
                case HeroTypeEnum.Swordsman:
                    Dead(attackedHero);
                    return;
            }
        }

        public void RiderAttack(Hero riderHero, Hero attackedHero)
        {
            switch (attackedHero.Type)
            {
                case HeroTypeEnum.Archery:
                case HeroTypeEnum.Rider:
                    Dead(attackedHero);
                    return;

                case HeroTypeEnum.Swordsman:
                    Dead(riderHero);
                    return;
            }
        }
    }
}
