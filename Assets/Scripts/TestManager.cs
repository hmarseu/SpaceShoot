using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestManager : MonoBehaviour
{
     public InputActionReference action;

    // Start is called before the first frame update
    void Start()
    {
        action.action.started += ctx => Temperature(ctx.ReadValue<float>());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Temperature(float temp)
    {
        Debug.Log("Temperature: " + temp);
    }
}
