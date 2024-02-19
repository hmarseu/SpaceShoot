using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] Button Pause;
    [SerializeField] Button Resume;

    private void Start()
    {
        Pause.onClick.AddListener(gameManager.HandlePause);
        Resume.onClick.AddListener(gameManager.HandleResume);
    }
    

}
