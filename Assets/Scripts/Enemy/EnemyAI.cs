using UnityEngine;
using System.Collections.Generic;

public class EnemyAI : MonoBehaviour
{
    public float speed = 3f;

    public List<EnemyRoad> availableRoads = new List<EnemyRoad>();
    public EnemyRoad chosenRoad;

    private int currentWaypoint = 0;

    void Start()
    {
        // Choisissez aléatoirement une route parmi celles disponibles
        if (availableRoads.Count > 0)
        {
            int randomIndex = Random.Range(0, availableRoads.Count);
            chosenRoad = availableRoads[randomIndex];

            // Mise à jour de la liste des routes disponibles pour tous les ennemis existants
            UpdateAvailableRoads();
        }
        else
        {
            Debug.LogError("Aucune route disponible pour l'ennemi.");
        }
    }

    void Update()
    {
        MoveToWaypoint();
    }

    void MoveToWaypoint()
    {
        if (currentWaypoint < chosenRoad.waypoints.Count)
        {
            Vector3 targetPosition = chosenRoad.waypoints[currentWaypoint].position;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            if (transform.position == targetPosition)
            {
                currentWaypoint++;
            }
        }
        else
        {
            // Le chemin est terminé, vous pouvez détruire l'ennemi ou gérer d'autres actions ici.
            Destroy(gameObject);
        }
    }

    void UpdateAvailableRoads()
    {
        EnemyRoad[] enemyRoads = FindObjectsOfType<EnemyRoad>();
        foreach (EnemyRoad enemyRoad in enemyRoads)
        {
            if (!availableRoads.Contains(enemyRoad))
            {
                availableRoads.Add(enemyRoad);
            }
        }
    }
}