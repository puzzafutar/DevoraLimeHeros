using DevoraLimeHeros.Domain;

namespace DevoraLimeHeros.Application.Manager.Interface
{
    public interface IArenaManager
    {
        int GenerateHeros(int heroCounter);

        string Fight(Arena selectedArena);

        Arena? GetArenaById(int id);
    }
}
