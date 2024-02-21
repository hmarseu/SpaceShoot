using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    [SerializeField] Button StartBtn;
    [SerializeField] Button EndBtn;

    private void Start()
    {
        StartBtn.onClick.AddListener(Load);
        EndBtn.onClick.AddListener(Leave);
    }
    private void Load()
    {
        SceneManager.LoadScene(1);
    }
    private void Leave()
    {
        Application.Quit();
    }
}
