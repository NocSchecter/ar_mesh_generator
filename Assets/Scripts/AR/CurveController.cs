using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurveController : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public static LineRenderer sharedLineRender;

    public float amplitude = 1;
    public float waveLenght = 1;
    public static int size = 50;

    private void Start()
    {
        DrawSineWave(amplitude, waveLenght);
        sharedLineRender = lineRenderer;
    }

    //dibuja una curva basadose de la formuala sinosidal y = A * sin(k * x)
    void DrawSineWave(float amplitude, float wavelength)
    {
        float x = 0f;
        float y;
        float k = 2 * Mathf.PI / wavelength;
        lineRenderer.positionCount = size;
        for (int i = 0; i < lineRenderer.positionCount; i++)
        {
            x += i * 0.001f;
            y = amplitude * Mathf.Sin(k * x);
            lineRenderer.SetPosition(i, new Vector3(x, y, 0) + this.gameObject.transform.position);
        }
    }
}
