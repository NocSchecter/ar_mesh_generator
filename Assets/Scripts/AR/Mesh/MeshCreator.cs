using UnityEngine;

public class MeshCreator : MonoBehaviour
{
    //Referencia al script que contiene la informacion de la posicion de las flechas
    public SpawnObject spawnObject;

    //Crea el plano
    public void Build()
    {
        Mesh mesh = CreateMesh();
        CreateMeshGameObject(mesh);
    }

    /**Crea los vertices de la malla tomando en cuenta la posición
    *de los puntos instanciados con el indicador (flecha)
    **/
    private Mesh CreateMesh()
    {
        Mesh mesh = new();

        Vector3[] vertices = spawnObject.positions.ToArray();

        int[] triangles = new int[3 * (vertices.Length - 2)];
        for (int i = 0; i < triangles.Length; i += 3)
        {
            triangles[i] = 0;
            triangles[i + 1] = i / 3 + 1;
            triangles[i + 2] = i / 3 + 2;
        }

        Vector3[] normals = CalculateNormals(vertices);

        Vector2[] uv = CalculateUV(vertices);

        Vector3 center = CalculateCenter(vertices);

        CenterUV(uv, center);

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.normals = normals;
        mesh.uv = uv;

        return mesh;
    }

    //Coloca los normales de la malla hacia arriba
    private Vector3[] CalculateNormals(Vector3[] vertices)
    {
        Vector3[] normals = new Vector3[vertices.Length];
        for (int i = 0; i < normals.Length; i++)
            normals[i] = Vector3.up;
        return normals;
    }

    //Calcula las coordenadas del mapa UV de los vertices de la malla
    private Vector2[] CalculateUV(Vector3[] vertices)
    {
        Vector2[] uv = new Vector2[vertices.Length];
        for (int i = 0; i < uv.Length; i++)
            uv[i] = new Vector2(vertices[i].x, vertices[i].z);
        return uv;
    }

    //Calcula el centro de la malla
    private Vector3 CalculateCenter(Vector3[] vertices)
    {
        Vector3 center = Vector3.zero;
        foreach (var vertex in vertices)
            center += vertex;

        center /= vertices.Length;
        return center;
    }

    /**Centra las coordenadas de la textura UV (Hasta ahora no me centra corrctamente la malla
    * y me doy cuenta cuando roto la textura con el shader)
    */
    private void CenterUV(Vector2[] uv, Vector3 center)
    {
        for (int i = 0; i < uv.Length; i++)
            uv[i] = new Vector2(uv[i].x - center.x, uv[i].y - center.z);
    }

    //Crea el objeto en la jerarqui, le agrega un nombre y asigna el material
    private void CreateMeshGameObject(Mesh mesh)
    {
        // Crear un GameObject con un MeshFilter y un MeshRenderer para mostrar el mesh
        GameObject meshObject = new GameObject("Floor");
        meshObject.AddComponent<MeshFilter>().mesh = mesh;
        MeshRenderer renderer = meshObject.AddComponent<MeshRenderer>();
        renderer.material = spawnObject.material;
    }
}