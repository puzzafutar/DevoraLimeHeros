using System.Runtime.InteropServices;

namespace DevoraLimeHeros.Domain
{
    public class Hero
    {
        public Hero(HeroTypeEnum heroType, int id, int maxHealtPoint)
        {
            Type = heroType;
            Id = id;
            HealtPoint = maxHealtPoint;
            MaxHealtPoint = maxHealtPoint;
        }

        public HeroTypeEnum Type { get; init; }

        public int Id { get; init; }

        public int HealtPoint { get; set; }

        public int MaxHealtPoint { get; init; }
    }
}
