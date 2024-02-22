using UnityEngine;

public class HealLoot : Loot
{
    public override void Use(Spaceship spaceship)
    {
        spaceship.Health++;
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