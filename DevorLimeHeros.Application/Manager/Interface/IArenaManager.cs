using DevoraLimeHeros.Domain;

namespace DevoraLimeHeros.Application.Manager.Interface
{
    public interface IArenaManager
    {
        int GenerateHeros(int heroCounter);

        string Fight(int ArenaId);

        List<Hero> Select2DifferentAliveHero(List<Hero> aliveHeros);

        bool HasArenaByID(int arenaId);

        Arena? GetArenaByID(int arenaId);
    }
}
