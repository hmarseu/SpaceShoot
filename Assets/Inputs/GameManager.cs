using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]private InputReader _input;
    [SerializeField] GameObject pauseMenu;

    bool _isPause = false;

    private void Start()
    {
        _input.PauseEvent += HandlePause;
        _input.ResumeEvent += HandleResume;

    }

    private void HandleResume()
    {
       pauseMenu.SetActive(false);
    }

    private void HandlePause()
    {
        pauseMenu.SetActive(true);
    }
}
