using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Curve : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public Vector3 position;
    public float amplitude = 1;
    public float waveLenght = 1;
    public int size = 100;

    private void Start()
    {
        DrawSineWave(position, amplitude, waveLenght);
    }

    void DrawSineWave(Vector3 startPoint, float amplitude, float wavelength)
    {
        float x = 0f;
        float y;
        float k = 2 * Mathf.PI / wavelength;
        lineRenderer.positionCount = size;
        for (int i = 0; i < lineRenderer.positionCount; i++)
        {
            x += i * 0.001f;
            y = amplitude * Mathf.Sin(k * x);
            lineRenderer.SetPosition(i, new Vector3(x, y, 0) + startPoint);
        }
    }
}
