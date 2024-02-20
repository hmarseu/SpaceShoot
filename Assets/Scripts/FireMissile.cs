using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMissile : MonoBehaviour
{

    public GameObject missilePrefab;

    public GameObject turretCannon;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FireMissileOnMouseClick();
        
    }


    void FireMissileOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject missile = ObjectPooling.Instance.GetProjectile();
            missile.transform.position = turretCannon.transform.position;
            missile.transform.rotation = turretCannon.transform.rotation;
        }
    }
}
