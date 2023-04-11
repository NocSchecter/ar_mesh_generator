using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class CollisionDetector : MonoBehaviour
{
    //Referencia al componente AARayCastManager
    private ARRaycastManager rayManager;

    private void Awake()
    {
        if (!rayManager)
            rayManager = FindObjectOfType<ARRaycastManager>();
    }

    /**
     * Lanza un rayo desde el centro de la pantalla y detectar
     * si hay un plano cercano actualiza la posición del objeto a la posición de colisión.
     */
    public void UpdatePosition()
    {
        List<ARRaycastHit> hitPoint = new List<ARRaycastHit>();
        rayManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hitPoint, TrackableType.PlaneWithinPolygon);

        if (hitPoint.Count > 0)
            transform.SetPositionAndRotation(hitPoint[0].pose.position, hitPoint[0].pose.rotation);
    }
}
