using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class ShakeManager : MonoBehaviour
{

    public float delay = 0.3f;
    public InputActionReference triggerShake;

    // Start is called before the first frame update
    void Start()
    {
        triggerShake.action.performed += ctx => ShakeScreen(ctx.ReadValue<float>());
    }

    // Update is called once per frame
    void Update()
    {
        if (delay > 0) delay -= Time.deltaTime;
    }

    public void ShakeScreen(float intensity)
    {
        if(intensity > 1.0f || intensity < -1.0f)
        {
            if (delay > 0)
            {
                delay -= Time.deltaTime;
                Debug.Log("too fast :/");
            }
            else
            {
                delay = 0.3f;
                Debug.Log("You are Shaking Hard :3");
            }
        }
    }
}
