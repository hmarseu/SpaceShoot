using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.InputSystem;

public class MouseManager : MonoBehaviour
{



    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    void PlaceNewTurret()
    {
        
        GameObject turret = EnnemyPooling.Instance.GetTurret();
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        turret.transform.position = mousePos;
    }
}
