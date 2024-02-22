using UnityEngine;

public class ShieldLoot : Loot
{
    public override void Use(Spaceship spaceship)
    {
        spaceship.HasShield = true;
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