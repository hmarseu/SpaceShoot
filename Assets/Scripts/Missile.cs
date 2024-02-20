using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    [SerializeField] public float speed = 5f; // Vitesse du missile

    private GameObject ObjectPooling;
    // Start is called before the first frame update
    void Start()
    {
        ObjectPooling = GameObject.Find("ObjectPooling Manager");
    }

    // Update is called once per frame
    void Update()
    {
        MoveForward();
        CheckOutOfScreen();
    }

    private void MoveForward()
    {
        // Obtenir la rotation initiale du missile
        Quaternion initialRotation = transform.rotation;

        // Convertir la rotation en vecteur direction
        Vector3 forwardDirection = initialRotation * Vector3.up;

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
            ObjectPooling.GetComponent<ObjectPooling>().ClearOneProjectile(gameObject);

            // Détruire le missile
            //Destroy(gameObject);
        }
    }

}
