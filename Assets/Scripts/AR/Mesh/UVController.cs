using UnityEngine;
using UnityEngine.UI;

public class UVController : MonoBehaviour
{
    //Slider que controla la rotacion del mapa UV del plano
    public Slider slider;

    /**
     * Se le asigna el valor del slider a la variable _Rotation del shader
     * para rotar la textura, es el mismo material del suelo
     */
    public void OnUVRotate()
    {
        SpawnObject.sharedMaterial.SetFloat("_Rotation", slider.value);
    }
}
