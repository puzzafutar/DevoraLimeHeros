using DevoraLimeHeros.Application.Factory.Interface;
using DevoraLimeHeros.Domain;
using DevoraLimeHeros.Application.Service.Interface;
using DevoraLimeHeros.Application.Provider.Interface;

namespace DevoraLimeHeros.Application.Service
{
    public class ArenaService : IArenaService
    {
        private readonly IHeroFactory _heroFactory;
        private readonly IRandomProvider _randomProvider;

        public ArenaService(IHeroFactory heroFactory, IRandomProvider randomProvider)
        {
            _heroFactory = heroFactory;
            _randomProvider = randomProvider;
        }


        public void GenerateHeroes(int heroCounter, Arena arena)
        {
            for (int i = 0; i < heroCounter; i++)
            {
                int heroType = _randomProvider.GetIntValue(Constants.Random.MaxRandomHeroType);
                arena.HeroList.Add(_heroFactory.GetHero((HeroTypeEnum)heroType, i + 1));
            }
        }
    }
}
