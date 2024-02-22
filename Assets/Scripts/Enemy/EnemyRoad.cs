using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRoad : MonoBehaviour
{
    public List<Transform> waypoints = new List<Transform>();

    // Start is called before the first frame update
    void Awake()
    {
        // Ajouter tous les enfants de EnemyRoad à la liste des waypoints
        foreach (Transform child in transform)
        {
            waypoints.Add(child);
        }

        // Ajouter cette route à la liste des routes disponibles dans EnemyAI
        UpdateAvailableRoads();
    }

    public void UpdateAvailableRoads()
    {
        EnemyAI[] enemyAIs = FindObjectsOfType<EnemyAI>();
        foreach (EnemyAI enemyAI in enemyAIs)
        {
            if (!enemyAI.availableRoads.Contains(this))
            {
                enemyAI.availableRoads.Add(this);
            }
        }
    }
}
