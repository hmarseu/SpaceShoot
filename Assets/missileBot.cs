using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missileBot : MonoBehaviour
{
    private void Update()
    {
        CheckOutOfScreen();
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
