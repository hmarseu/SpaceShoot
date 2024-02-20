using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.InputSystem;

public class FollowMouseTurret : MonoBehaviour
{
    public InputActionReference mousePositionAction;

    void Start()
    {
        // Attachez l'action de la souris pour suivre sa position
        mousePositionAction.action.performed += ctx => FollowMouse2D(ctx.ReadValue<Vector2>());
    }

    void FollowMouse2D(Vector2 mousePosition)
    {
        Vector3 mousePos = mousePosition;
        mousePos.z = 10;
        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;
        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    private void OnEnable()
    {
        mousePositionAction.action.Enable();
    }

    private void OnDisable()
    {
        mousePositionAction.action.Disable();
    }
}
