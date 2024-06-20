using DevoraLimeHeros.Domain;

namespace DevoraLimeHeros.Application.Service.Interface
{
    public interface IArenaService
    {
        void GenerateHeroes(int heroCounter, Arena arena);
    }
}
