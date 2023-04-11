using UnityEngine;

[RequireComponent(typeof(PointerManager))]
[RequireComponent(typeof(CollisionDetector))]

public class PlacementPointerManager : MonoBehaviour
{
    //Referencia al script que muestra el puntero
    private PointerManager pointerManager;
    //Referencia al script que actualiza la posicion del puntero
    private CollisionDetector collisionDetector;

    private void Awake()
    {
        pointerManager = GetComponent<PointerManager>();
        collisionDetector = GetComponent<CollisionDetector>();
    }

    //Actualiza la posicion del puntero
    private void Update()
    {
        collisionDetector.UpdatePosition();
    }
}
