namespace DevoraLimeHeros.Domain
{
    public class Hero
    {
        public HeroTypeEnum Type { get; set; }

        public int Id { get; set; }

        public int HealtPoint { get; set; }

        public int MaxHealtPoint { get; set; }
    }
}
