using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    //Objetos de la interfaz de usuario
    [SerializeField] private GameObject popUp;
    [SerializeField] private GameObject menu;

    [SerializeField] private GameObject contentBtnArrow;
    [SerializeField] private GameObject contentBtnRetrace;
    [SerializeField] private GameObject btnStart;
    [SerializeField] private GameObject btnFinish;
    [SerializeField] private GameObject btnAdd;
    [SerializeField] private GameObject btnRemove;

    //Estados
    private bool isPopupActive = true;
    private bool isPlaneDetected = false;

    void Start()
    {
        btnAdd.GetComponent<Button>().interactable = false;
        btnRemove.GetComponent<Button>().interactable = false;
    }

    private void OnEnable()
    {
        SpawnObject.instantiateGo += ShowPopUp;
        SpawnObject.instantiateGo += ShowArrows;
        PlaneDetectionController.OnPlaneDetected += PlaneDetect;
    }

    private void OnDisable()
    {
        PlaneDetectionController.OnPlaneDetected -= PlaneDetect;
    }

    private void OnDestroy()
    {
        SpawnObject.instantiateGo -= ShowPopUp;
        SpawnObject.instantiateGo -= ShowArrows;
    }

    //Oculta el boton de inicio y muestra el mensaje popUp
    public void PrepareStartUI()
    {
        btnStart.SetActive(false);
        popUp.SetActive(true);

    }

    //Oculta el boton de finalización, y muestra el menú
    public void PrepareFinishUI()
    {
        btnFinish.SetActive(false);
        menu.SetActive(true);
        contentBtnArrow.SetActive(false);
        contentBtnRetrace.SetActive(true);
    }

    //Mustra el mensaje de popUP
    private void ShowPopUp(int instance)
    {
        if(isPopupActive && instance >= 0)
        {
            popUp.SetActive(false);
            isPopupActive = false;
        }
    }

    /*Muestra el boton de finalización si se crea un tercer objeto
     * (Tiene sentido que se construya el plano cuando haya minimo 3 flechas)
     */
    private void ShowArrows(int instance)
    {
        if (instance == 2)
            btnFinish.SetActive(true);
    }

    //Se habilita el boton add si la deteccion de planos esta activa
    private void PlaneDetect()
    {
        if (!isPlaneDetected)
        {
            isPlaneDetected = true;
            btnAdd.GetComponent<Button>().interactable = true;
        }
    }
}
