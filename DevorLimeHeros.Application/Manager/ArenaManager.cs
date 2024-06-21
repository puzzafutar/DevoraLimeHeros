using DevoraLimeHeros.Application.Service.Interface;
using DevoraLimeHeros.Application.Manager.Interface;
using DevoraLimeHeros.Application.Provider.Interface;
using System.Text;
using DevoraLimeHeros.Domain;

namespace DevoraLimeHeros.Application.Manager
{
    public class ArenaManager : IArenaManager
    {
        private readonly List<Arena> _arenaList;
        private readonly List<AttackResult> _attackResultList;

        private readonly IArenaService _arenaService;
        private readonly IHeroService _heroService;
        private readonly IRandomProvider _randomProvider;

        public ArenaManager(IArenaService arenaService, IHeroService heroService, IRandomProvider randomProvider)
        {
            _arenaList = new List<Arena>();
            _attackResultList = new List<AttackResult>();

            _arenaService = arenaService;
            _heroService = heroService;
            _randomProvider = randomProvider;
        }

        private List<Hero> GetAliveHeroList(Arena arena)
        {
            return arena.HeroList.Where(hero => hero.HealtPoint > 0).ToList();
        }

        public string Fight(Arena selectedArena)
        {
            StringBuilder stringBuilderResult = new StringBuilder();
            _attackResultList.Clear();

            //harc implementáció
            do
            {
                List<Hero> aliveHeros = GetAliveHeroList(selectedArena);

                var selectedHeros = Select2DifferentAliveHero(aliveHeros);

                //Támadó
                Hero attackHero = selectedHeros.First();
                
                //Védekező
                Hero attackedHero = selectedHeros.Last();
                
                //A többi elküldjük pihenni
                foreach (Hero hero in aliveHeros)
                {
                    _heroService.Relax(hero);
                }

                //a kiválasztottak összecsapnak
                var attackresult = new AttackResult(attackHero,attackedHero);

                stringBuilderResult.AppendLine(attackresult.GetBeforeAttackString());

                var attackRersult = _heroService.Attack(attackHero, attackedHero);

                stringBuilderResult.AppendLine(attackRersult.GetAfterAttackString());

                _attackResultList.Add(attackRersult);

            } while (GetAliveHeroList(selectedArena).Count > Constants.Hero.MinHeroCounter);

            stringBuilderResult.AppendLine($"{_attackResultList.Count} kör volt");

            return stringBuilderResult.ToString();

        }

        public int GenerateHeros(int heroCounter)
        {
            Arena arena = new Arena(_arenaList.Count() + 1);
            _arenaList.Add(arena);
            _arenaService.GenerateHeroes(heroCounter, arena);
            return arena.Id;
        }

        public Arena? GetArenaById(int arenaId)
        {
            return _arenaList.Where(arena => arena.Id == arenaId).FirstOrDefault();
        }

        private List<Hero> Select2DifferentAliveHero(List<Hero> aliveHeros)
        {
            List<Hero> seletedResult = new List<Hero>();

            Hero attackHero = aliveHeros[_randomProvider.GetIntValue(aliveHeros.Count)];
            aliveHeros.Remove(attackHero);
            Hero attackedHero = null;
            do
            {
                attackedHero = aliveHeros[_randomProvider.GetIntValue(aliveHeros.Count)];

            } while (attackHero == attackedHero);

            if (attackHero == attackedHero)
            {
                throw new Exception("Ugyanaz a hős van kiválasztva!");
            }

            aliveHeros.Remove(attackedHero);

            return new List<Hero> { attackHero, attackedHero };

        }
    }
}
