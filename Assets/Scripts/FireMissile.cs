using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.InputSystem;

public class FireMissile : MonoBehaviour
{

    public GameObject missilePrefab1;
    public GameObject missilePrefab2;
    public GameObject missilePrefab3;

    public GameObject turretCannon;

    public InputActionReference triggerAction1;
    public InputActionReference triggerAction2;
    public InputActionReference triggerAction3;


    public GameObject GlobalPoolObject;
        
    // Start is called before the first frame update
    void Start()
    {
        triggerAction1.action.performed += ctx => FireMissileOnMouseClick(missilePrefab1);
        triggerAction2.action.performed += ctx => FireMissileOnMouseClick(missilePrefab2);
        triggerAction3.action.performed += ctx => FireMissileOnMouseClick(missilePrefab3);

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void FireMissileOnMouseClick(GameObject missilePrefab)
    {

        GameObject missile = GlobalPoolObject.GetComponent<GlobalPoolObject>().GetEmpty();
        GlobalPoolObject.GetComponent<GlobalPoolObject>().FuseComponents(missilePrefab, missile);
        missile.transform.position = turretCannon.transform.position;
        missile.transform.rotation = turretCannon.transform.rotation;
    }
}
