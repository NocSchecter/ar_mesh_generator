using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    //Variable que hace referencia al script que calcula la posicion y rotacion del puntero
    public CollisionDetector collisionDetector;

    //Evento que se desencadena cuando se realiza una instancia
    public delegate void OnInstantiateGo(int instance);
    public static event OnInstantiateGo instantiateGo;

    //Referencia al prefab de las flechas que indican el �rea de selecci�n
    public GameObject objectToSpawn;
    //Linea que se agregara entre las felchas instanceadas
    public LineRenderer lineRenderer;

    //Cantidad maxima de instancias
    public int maxInstances = 5;
    //Variable que sirve para hacer un conteo del n�mero de instancias creadas
    private int currentInstances = 0;

    //Almacena la posici�n de las flechas instanciadas en la pantalla
    internal List<Vector3> positions = new();
    //Almacena la rotaci�n de las flechas instanciadas en la pantalla
    private List<Quaternion> rotations = new();
    //Almacena las flechas instanciadas en la pantalla
    private List<GameObject> objectList = new ();

    public static Material sharedMaterial;
    public Material material;

    private void Awake()
    {
        sharedMaterial = material;
    }

    private void Start()
    {
        DisableLines();
    }

    /**
     * Se utiliza para crear un nuevo objeto que se ha especificado.
    *Si se ha alcanzado el l�mite m�ximo de instancias,
    *el objeto no se generar�.
    **/
    public void Spawn()
    {
        if (currentInstances < maxInstances)
        {
            collisionDetector.UpdatePosition();

            Vector3 position = collisionDetector.transform.position;
            Quaternion rotation = collisionDetector.transform.rotation;

            GameObject go = Instantiate(objectToSpawn, position, rotation);

            instantiateGo?.Invoke(currentInstances);

            positions.Add(position);
            rotations.Add(rotation);
            objectList.Add(go);

            currentInstances++;

            DrawLines();

        }
    }
    //Se utiliza para ocultar todos los objetos generados previamente.
    public void HideObject()
    {
        for (int i = 0; i < objectList.Count; i++)
            objectList[i].SetActive(false);
    }

    /**
     * Se utiliza para dibujar las l�neas que conectan los objetos generados previamente.
    *Si la posici�n de los objetos es mayor que 1 y se ha asignado un "LineRenderer" al objeto,
    *se dibujar�n las l�neas. Adem�s, si la posici�n es mayor que 3,
    *se cierra la l�nea al dibujar una l�nea entre la �ltima posici�n y la primera posici�n.
    **/
    private void DrawLines()
    {
        if (positions.Count > 1 && lineRenderer != null)
        {
            EnableLines();

            lineRenderer.positionCount = positions.Count;

            for (int i = 0; i < positions.Count; i++)
                lineRenderer.SetPosition(i, positions[i]);

            if (positions.Count > 3)
            {
                lineRenderer.positionCount += 1;
                lineRenderer.SetPosition(positions.Count, positions[0]);
            }
        }
    }

    //Se utiliza para desactivar la visualizaci�n de las l�neas.
    public void DisableLines()
    {
        if (!lineRenderer)
            return;

        lineRenderer.enabled = false;
    }

    //Se utiliza para activar la visualizaci�n de las l�neas.
    public void EnableLines()
    {
        lineRenderer.enabled = true;
    }
}