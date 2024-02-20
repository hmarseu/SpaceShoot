using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlaceNewTurret();
    }

    void PlaceNewTurret()
    {
        if (Input.GetMouseButtonDown(1))
        {
            GameObject turret = EnnemyPooling.Instance.GetTurret();
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            turret.transform.position = mousePos;
        }
    }
}
