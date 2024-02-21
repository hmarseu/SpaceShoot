using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{/*
    [SerializeField] InputReader input;
    [SerializeField] float speed;
    [SerializeField] Camera camera;

    Vector2 _moveDirection;

    private float minX, maxX,minY,maxY;

    private void Start()
    {
        input.MoveEvent += HandleMove;
        camera = Camera.main;

        Vector3 bottomLeft = camera.ViewportToWorldPoint(new Vector3(0, 0, camera.farClipPlane));
        Vector3 topRight = camera.ViewportToWorldPoint(new Vector3(1, 1, camera.farClipPlane));
       
        // D�finir les limites de d�placement du joueur en fonction de la vue de la cam�ra
        minX = bottomLeft.x;
        maxX = topRight.x;
        minY = bottomLeft.y;
        maxY = topRight.y;

    }

    
    private void HandleMove(Vector2 vector)
    {
        _moveDirection = vector;
    }
    private void Move()
    {
        if (_moveDirection == Vector2.zero)
        {
            return;
        }
        //transform.position += new Vector3(_moveDirection.x, 0, 0) * (speed * Time.deltaTime);

        //
        Vector3 newPosition = transform.position + new Vector3(_moveDirection.x, _moveDirection.y, 0) * speed * Time.deltaTime;

        // Appliquer les limites horizontales
        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);

        // Appliquer les limites verticales
        newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);

        // D�placer le joueur vers la nouvelle position
        transform.position = newPosition;
    }
    
    private void Update()
    {
        Move();
     
    }*/
}
