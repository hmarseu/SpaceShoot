public class MissileLoot : Loot
{
    public override void Use(Spaceship spaceship)
    {
        //if (spaceship.MissileLevel == spaceship.MaxMissileLevel)
        //    return;
        
        spaceship.MissileLevel++;
    }
}