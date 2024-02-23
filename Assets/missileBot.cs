using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missileBot : MonoBehaviour
{
    [SerializeField]
    public float speed = 10f;
    private void Update()
    {
        MoveBackWard();
        CheckOutOfScreen();
    }

    
    
      
        
    

    private void MoveBackWard()
    {
        // Obtenir la rotation initiale du missile
        Quaternion initialRotation = transform.rotation;

        // Convertir la rotation en vecteur direction
        Vector3 forwardDirection = initialRotation * Vector3.down;

        // D�placer le missile dans la direction vers l'avant
        transform.position += forwardDirection * speed * Time.deltaTime;
    }
    private void CheckOutOfScreen()
    {
        // Obtenir la position du missile dans l'�cran
        Vector3 viewportPosition = Camera.main.WorldToViewportPoint(transform.position);

        // V�rifier si le missile est en dehors de l'�cran
        if (viewportPosition.x < 0 || viewportPosition.x > 1 || viewportPosition.y < 0 || viewportPosition.y > 1)
        {
            // Le missile est sorti de l'�cran, vous pouvez ex�cuter une action ici (par exemple, d�truire le missile)
            GlobalPoolObject.Instance.ClearOneEmpty(gameObject);

            // D�truire le missile
            //Destroy(gameObject);
        }
    }
}
