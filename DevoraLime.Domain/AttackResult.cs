namespace DevoraLimeHeros.Domain
{
    public class AttackResult
    {
        public AttackResult(Hero attackHero, Hero attackedHero)
        {
            AttackHero = attackHero;
            AttackedHero = attackedHero;
        }

        public Hero AttackHero { get; init; }

        public Hero AttackedHero { get; init; }

        public override string ToString()
        {
            Hero winner = AttackHero.HealtPoint > AttackedHero.HealtPoint ? AttackHero : AttackedHero;

            return $"Támadó: {AttackHero.Type} id: {AttackHero.Id} hp: {AttackHero.HealtPoint}, Védekező: {AttackedHero.Type} id: {AttackedHero.Id} hp: {AttackedHero.HealtPoint}, a győztes: {winner.Type} id: {winner.Id} ";
        }
    }
}
