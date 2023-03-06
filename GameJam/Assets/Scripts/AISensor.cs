using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISensor : MonoBehaviour
{
    public float distance = 10;
    public float angle = 30;
    public float height = 1.0f;
    public Color meshColor = Color.red;

    Mesh mesh;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    Mesh CreateWedgeMesh()
    {
        Mesh mesh = new Mesh();

        int numTriangles = 8;
        int numVertices = numTriangles * 3;

        Vector3[] vertices = new Vector3[numVertices];
        int[] triangles = new int[numVertices];

        Vector3 bottomCenter = Vector3.zero;
        Vector3 bottomleft = Quaternion.Euler(0, -angle, 0) * Vector3.forward * distance;
        Vector3 bottomright = Quaternion.Euler(0, angle, 0) * Vector3.forward * distance;


        Vector3 topCenter = bottomCenter + Vector3.up * height;
        Vector3 topLeft = bottomleft + Vector3.up * height;
        Vector3 topRight = bottomright + Vector3.up * height;

        int vert = 0;

        //left side
        vertices[vert++] = bottomCenter;
        vertices[vert++] = bottomleft;
        vertices[vert++] = topLeft;

        vertices[vert++] = topLeft;
        vertices[vert++] = topCenter;
        vertices[vert++] = bottomCenter;

        //rightside
        vertices[vert++] = bottomCenter;
        vertices[vert++] = topCenter;
        vertices[vert++] = topRight;

        vertices[vert++] = topRight;
        vertices[vert++] = bottomright;
        vertices[vert++] = bottomCenter;
        //farside


        vertices[vert++] = bottomleft;
        vertices[vert++] = bottomright;
        vertices[vert++] = topRight;

        vertices[vert++] = topRight;
        vertices[vert++] = topLeft;
        vertices[vert++] = bottomleft;

        //top
        vertices[vert++] = topCenter;
        vertices[vert++] = topLeft;
        vertices[vert++] = topRight;


        //bottom


        vertices[vert++] = bottomCenter;
        vertices[vert++] = bottomright;
        vertices[vert++] = bottomleft;

        for (int i = 0; i < numVertices; ++i)
        {
            triangles[i] = i;
        }

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
        return mesh;

    }

    private void OnValidate()
    {
        mesh = CreateWedgeMesh();
    }

    private void OnDrawGizmos()
    {
        Debug.Log("in Draw Gizmoz");
        if (mesh)
        {
            Debug.Log("Mesh created");
            Gizmos.color = meshColor;
            Gizmos.DrawMesh(mesh, transform.position, transform.rotation);
        }
    }
}
