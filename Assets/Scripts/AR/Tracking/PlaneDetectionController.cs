using System;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class PlaneDetectionController : MonoBehaviour
{
    //Referencia al script que se encarga de la detección de planos
    public ARPlaneManager aRPlaneManager;

    //Evento
    public delegate void PlaneDetectedEventHandler();
    public static event PlaneDetectedEventHandler OnPlaneDetected;

    private void Awake()
    {
        if (!aRPlaneManager)
            aRPlaneManager = FindObjectOfType<ARPlaneManager>();
    }

    private void Start()
    {
        PlaneDetection(false);
    }

    //Activa o desactiva la deteccion de los planos
    private void PlaneDetection(bool state)
    {
        aRPlaneManager.enabled = state;
    }

    //Inicia la deteccion de planos y genera un evento
    public void OnStartPlaneDetection()
    {
        PlaneDetection(true);
        OnPlaneDetected?.Invoke();
    }

    //Detiene la deteccion de planos y los desativa
    public void OnStopPlaneDetection()
    {
        PlaneDetection(false);
        foreach (var plane in aRPlaneManager.trackables)
            plane.gameObject.SetActive(false);
        }
}
