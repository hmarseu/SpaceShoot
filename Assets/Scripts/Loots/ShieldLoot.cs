public class ShieldLoot : Loot
{
    public override void Use(Spaceship spaceship)
    {
        spaceship.HasShield = true;
    }
}