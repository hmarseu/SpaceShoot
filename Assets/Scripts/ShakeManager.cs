using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShakeManager : MonoBehaviour
{
    public float delay = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    
    void Update()
    {
        delay -= Time.deltaTime;
    }

    public void Shake()
    {
        if (delay <= 0)
        {
            GameObject player = GameObject.Find("Player");

            //color random pour le sprite
            player.GetComponent<SpriteRenderer>().color = new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f));
            delay = 0.5f;

            //vibrate the phone
            Handheld.Vibrate();
            
        }
    }
}
