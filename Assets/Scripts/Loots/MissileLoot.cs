using UnityEngine;

public class MissileLoot : Loot
{
    public override void Use(Spaceship spaceship)
    {
        //if (spaceship.MissileLevel == spaceship.MaxMissileLevel)
        //    return;
        
        spaceship.MissileLevel++;
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Spaceship ss = other.GetComponent<Spaceship>();
            if (other.GetComponent<Spaceship>())
            {
                Use(ss);

            }
        }
    }
}