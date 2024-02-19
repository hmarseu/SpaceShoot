public class MissileLoot : Loot
{
    public override void Use(Spaceship spaceship)
    {
        spaceship.MissileLevel++;
    }
}