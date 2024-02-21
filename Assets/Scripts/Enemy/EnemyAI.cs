using UnityEngine;
using System.Collections.Generic;

public class EnemyAI : MonoBehaviour
{
    public float speed = 3f;
    public float rotationSpeed = 5f;

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

            // Direction vers le prochain waypoint
            Vector3 directionToTarget = targetPosition - transform.position;

            // Normalisez la direction pour avoir une longueur de 1, puis multipliez par la vitesse
            Vector3 moveDirection = directionToTarget.normalized;
            Vector3 newPosition = transform.position + moveDirection * speed * Time.deltaTime;

            // Déplacer l'ennemi à la nouvelle position
            transform.position = newPosition;

            // Rotation progressive vers le waypoint sur l'axe Z uniquement
            float angle = Mathf.Atan2(directionToTarget.y, directionToTarget.x) * Mathf.Rad2Deg;
            Quaternion rotationToTarget = Quaternion.Euler(0f, 0f, angle - 90f);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotationToTarget, rotationSpeed * Time.deltaTime);

            // Si la distance entre l'ennemi et le waypoint est inférieure à une petite valeur, passez au prochain waypoint
            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
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