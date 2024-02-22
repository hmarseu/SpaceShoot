using UnityEngine;
using System.Collections.Generic;

public class EnemyAI : MonoBehaviour
{
    public float speed = 3f;
    public float rotationSpeed = 5f;

    public float timeBetweenShots = 1f; 
    private float timeSinceLastShot = 0f;
    public float missileSpeed;

    public bool canShoot;

    public delegate void aiDied( Vector3 pos,bool gold);
    public static event aiDied enemyDie;

    public List<EnemyRoad> availableRoads = new List<EnemyRoad>();
    public EnemyRoad chosenRoad;

    public GameObject missilePrefab;

    private int currentWaypoint = 0;
    private void OnEnable()
    {
        UpdateAvailableRoads();
    }
    void Start()
    {
        // Initialisation du temps écoulé depuis le dernier tir
        timeSinceLastShot = timeBetweenShots;

        // Choisit aléatoirement une route parmi celles disponibles
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

        if (canShoot && Time.time - timeSinceLastShot > timeBetweenShots)
        {
            Shoot();
            timeSinceLastShot = Time.time; // Met à jour le temps du dernier tir
        }
    }

    void MoveToWaypoint()
    {
        if (currentWaypoint < chosenRoad.waypoints.Count)
        {
            Vector3 targetPosition = chosenRoad.waypoints[currentWaypoint].position;

            // Direction vers le prochain waypoint
            Vector3 directionToTarget = targetPosition - transform.position;

            // Permet d'avoir une vitesse constante entre chaque waypoint
            Vector3 moveDirection = directionToTarget.normalized;
            Vector3 newPosition = transform.position + moveDirection * speed * Time.deltaTime;

            // Déplace l'ennemi à la nouvelle position
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
            //Une fois le dernier waypoint atteint, détruis le GameObject
            enemyDie(new Vector3(100, 100, 0), false);
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

    void Shoot()
    {
        Debug.Log("L'ennemi tire !");

        GameObject missile = Instantiate(missilePrefab, transform.position, Quaternion.identity);

        // Applique une force vers le bas pour simuler le mouvement du missile
        Rigidbody2D missileRb = missile.GetComponent<Rigidbody2D>();
        missileRb.AddForce(Vector2.down * missileSpeed, ForceMode2D.Impulse);
    }
}