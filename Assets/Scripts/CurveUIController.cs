using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurveUIController : MonoBehaviour
{
    //Referencia al objeto que se muvera en la curva
    public GameObject ObjectToMove;
    //Slider que mueve el objeto en la curva
    public Slider slider;

    private void Start()
    {
        ObjectToMove.SetActive(false);
    }

    /**Se establecen los valores iniciales del slider
     * Tomando como datos iniciales el valor 0 y el numero
     * de posiciones totales de la curva menos 1
     */
    public void SetSliderRange()
    {
        slider.minValue = 0;
        slider.maxValue = CurveController.size - 1;
        ObjectToMove.SetActive(true);
    }

    //Se le asigna al evento del slider el metodo que mueve el objeto en la curva
    public void SetSliderChangeEvent()
    {
        slider.onValueChanged.AddListener(delegate { MoveObject(); });
    }

    //Mueve el objeto siguiendo la onda de la curva
    private void MoveObject()
    {
        ObjectToMove.transform.position = CurveController.sharedLineRender.GetPosition((int)slider.value);
    }
}
