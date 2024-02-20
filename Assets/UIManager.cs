using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameManagerInputs gameManager;
    [SerializeField] Button Pause;
    [SerializeField] Button Resume;
    [SerializeField] Button Quit;

    private void Start()
    {
        Pause.onClick.AddListener(gameManager.HandlePause);
        Resume.onClick.AddListener(gameManager.HandleResume);
        Quit.onClick.AddListener(Leave);
    }
    private void Leave()
    {
        gameManager.HandleResume();
        SceneManager.LoadScene(0);
    }

}
