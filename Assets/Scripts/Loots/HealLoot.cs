public class HealLoot : Loot
{
    public override void Use(Spaceship spaceship)
    {
        spaceship.Health++;
    }
}