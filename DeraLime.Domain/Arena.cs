namespace DevoraLimeHeros.Domain
{
    public class Arena
    {
        public int Id { get; init; }

        public List<Hero> HeroList { get; init; }

        public List<AttackResult> RoundList { get; init; }

        public Arena(int id)
        {
            Id = id;
            HeroList = new List<Hero>();
            RoundList = new List<AttackResult>();
        }
    }
}
