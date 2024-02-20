using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerInputs : MonoBehaviour
{
    [SerializeField]private InputReader _input;
    [SerializeField] GameObject pauseMenu;

    bool _isPause = false;

    private void Start()
    {
        _input.PauseEvent += HandlePause;
        _input.ResumeEvent += HandleResume;

    }

    public void HandleResume()
    {
        _isPause = false;
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }

    public void HandlePause()
    {
        _isPause = true;
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }
}
