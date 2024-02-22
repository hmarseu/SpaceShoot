using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "InputReader")]
public class InputReader : ScriptableObject, GameInputMain.IGameplayActions, GameInputMain.IUIActions
{
    GameInputMain _gameInput;
    private void OnEnable()
    {
        if (_gameInput == null)
        {
            _gameInput = new();
            _gameInput.Gameplay.SetCallbacks(this);
            _gameInput.UI.SetCallbacks(this);
            SetGameplay();
        }
    }

    public void SetGameplay()
    {
        _gameInput.Gameplay.Enable();
        _gameInput.UI.Disable();
    }
    public void SetUI()
    {
        _gameInput.Gameplay.Disable();
        _gameInput.UI.Enable();
    }

    public event Action<Vector2> MoveEvent;
    public event Action JumpEvent;
    public event Action JumpCancelledEvent;

    public event Action ResumeEvent;
    public event Action PauseEvent;
   

    public void OnMove(InputAction.CallbackContext context)
    {
        //Debug.Log($"Phase:{context.phase},Value : {context.ReadValue<Vector2>()}");
        MoveEvent?.Invoke(context.ReadValue<Vector2>());
    }

    public void OnPause(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            PauseEvent?.Invoke();
            SetUI();
        }
    }

    public void OnResume(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            ResumeEvent?.Invoke();
            SetGameplay();
        }
    }

    public void OnShake(InputAction.CallbackContext context)
    {
        GameObject shakeManager = GameObject.Find("Shake Manager");

        if (context.phase == InputActionPhase.Performed)
        {
            if(context.ReadValue<float>() > 1.0f || context.ReadValue<float>() < -1.0f) shakeManager.GetComponent<ShakeManager>().Shake(context.ReadValue<float>());
        }
    }
}
