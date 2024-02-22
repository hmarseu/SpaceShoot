using UnityEngine;

public class BombLoot : Loot
{
    public override void Use(Spaceship spaceship)
    {
        spaceship.BombCount++;
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision détectée avec : " + other.gameObject.name);
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