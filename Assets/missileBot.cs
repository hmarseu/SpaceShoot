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

        // Déplacer le missile dans la direction vers l'avant
        transform.position += forwardDirection * speed * Time.deltaTime;
    }
    private void CheckOutOfScreen()
    {
        // Obtenir la position du missile dans l'écran
        Vector3 viewportPosition = Camera.main.WorldToViewportPoint(transform.position);

        // Vérifier si le missile est en dehors de l'écran
        if (viewportPosition.x < 0 || viewportPosition.x > 1 || viewportPosition.y < 0 || viewportPosition.y > 1)
        {
            // Le missile est sorti de l'écran, vous pouvez exécuter une action ici (par exemple, détruire le missile)
            GlobalPoolObject.Instance.ClearOneEmpty(gameObject);

            // Détruire le missile
            //Destroy(gameObject);
        }
    }
}
