using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyPooling : MonoBehaviour
{
    public static EnnemyPooling Instance;
    public GameObject TurretPrefab;
    public int PoolSize = 5;

    private List<GameObject> _turrets;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _turrets = new List<GameObject>();

        for (int i = 0; i < PoolSize; i++)
        {
            GameObject turret = Instantiate(TurretPrefab, transform);
            turret.SetActive(false);
            _turrets.Add(turret);
        }  
    }
    public GameObject GetTurret()
    {
        for (int i = 0 ; i < _turrets.Count; i++)
        {
            if (!_turrets[i].activeInHierarchy)
            {
                _turrets[i].SetActive(true);
                return _turrets[i];
            }
        }

        GameObject newTurret = Instantiate(TurretPrefab, transform);
        _turrets.Add(newTurret);
        newTurret.SetActive(true);
        return newTurret;
    }
    public void ClearOneProjectile(GameObject turret)
    {
        turret.SetActive(false);
    }
    public void ClearProjectilePool()
    {
        foreach (GameObject turret in _turrets)
        {
            Destroy(turret);
        }
        _turrets.Clear();
    }
}
