using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float speed = 3f;
    public EnemyRoad enemyRoad;
    private int currentWaypoint = 0;

    void Update()
    {
        MoveToWaypoint();
    }

    void MoveToWaypoint()
    {
        if (currentWaypoint < enemyRoad.waypoints.Count)
        {
            Vector3 targetPosition = enemyRoad.waypoints[currentWaypoint].position;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            if (transform.position == targetPosition)
            {
                currentWaypoint++;
            }
        }
        else
        {
            // Le chemin est termin�, vous pouvez d�truire l'ennemi ou g�rer d'autres actions ici.
            Destroy(gameObject);
        }
    }
}