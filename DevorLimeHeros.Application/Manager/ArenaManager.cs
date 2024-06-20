using DevorLimeHeros.Application.Providers;
using DevoraLimeHeros.Domain;
using DevoraLimeHeros.Application.Service.Interface;
using DevoraLimeHeros.Application.Manager.Interface;
using DevoraLimeHeros.Application.Provider.Interface;
using System.Text;

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
            _attackResultList.Clear();

            //harc implementáció
            //véletlenszerűen kiválasztok 2 elő hőst és nem harcolhat önmagával
            do
            {
                List<Hero> aliveHeros = GetAliveHeroList(selectedArena);

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
                //A többi elküldjük pihenni
                foreach (Hero hero in aliveHeros)
                {
                    _heroService.Relax(hero);
                }

                //a kiválasztottak összecsapnak
                var attackRersult = _heroService.Attack(attackHero, attackedHero);
                _attackResultList.Add(attackRersult);

            } while (GetAliveHeroList(selectedArena).Count > Constants.Hero.MinHeroCounter);

            StringBuilder resultStringBuilder = new StringBuilder();
            resultStringBuilder.AppendLine($"{_attackResultList.Count} kör volt, részeredmények:");

            foreach (var attack in _attackResultList)
            {
                resultStringBuilder.AppendLine(attack.ToString());
            }

            return resultStringBuilder.ToString();

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
    }
}
