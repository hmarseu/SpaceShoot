using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRoad : MonoBehaviour
{
    public List<Transform> waypoints = new List<Transform>();

    // Start is called before the first frame update
    void Start()
    {
        // Ajouter tous les enfants de EnemyRoad à la liste des waypoints
        foreach (Transform child in transform)
        {
            waypoints.Add(child);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
