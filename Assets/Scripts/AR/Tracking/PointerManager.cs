using UnityEngine;

public class PointerManager : MonoBehaviour
{
    //Referencia al puntero (Felcha que aparece en la pantalla)
    private GameObject pointerObject;

    private void Awake()
    {
        if (!pointerObject)
            pointerObject = this.transform.GetChild(0).gameObject;
    }

    private void Start()
    {
        HidePointer();
    }

    //Muestra el objeto puntero en la escena.
    public void ShowPointer()
    {
        pointerObject.SetActive(true);
    }

    //Esconde el objeto puntero en la escena.
    public void HidePointer()
    {
        pointerObject.SetActive(false);
    }
}
