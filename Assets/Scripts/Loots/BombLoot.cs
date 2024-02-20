public class BombLoot : Loot
{
    public override void Use(Spaceship spaceship)
    {
        spaceship.BombCount++;
    }
}