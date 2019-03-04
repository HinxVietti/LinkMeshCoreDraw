using HinxCor.Unity.SCD;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable
public class DemoCreateRectangle : MonoBehaviour
{
    const float angle = 60.9453937774702f;
    const float length = 20.59126f;
    private static float deg { get { return angle / 180f * Mathf.PI; } }

    public Drawable rectangle;

    Rect rect;

    private void Start()
    {
        var p1 = new Vector2(-10, -18);
        var p2 = new Vector2(10, -18);
        var p3 = Vector2.up;
        double tans = 360 / 2 / Mathf.PI;

        var θ1 = Mathf.Atan(p3.y / p3.x) * tans;
        //print(θ1);// =π/2
        var θ2 = Mathf.Atan(p2.y / p2.x) * tans;
        var θ3 = Mathf.Atan(p1.y / p1.x) * tans;
        //print(Mathf.Tan(0) + " + " + Mathf.Tan(Mathf.PI / 2.0001f));
        //print(p1.magnitude);

    }


    public void DrawAngle(Vector2 start, Vector2 end)
    {
        var dir = (end - start).normalized;
        var angle = Mathf.Atan(dir.y / dir.x);
        if (dir.x <= 0) angle += Mathf.PI;
        var a1 = angle - Mathf.PI / 2 - deg;
        var a2 = angle + Mathf.PI / 2 + deg;
        var pa = new Vector2(Mathf.Sin(a1), Mathf.Cos(a1)) * length + end;
        var pb = new Vector2(Mathf.Sin(a2), Mathf.Cos(a2)) * length + end;


        Mesh mesh = new Mesh();
        mesh.name = "new triangle";

        mesh.Clear();
        List<Vector3> points = new List<Vector3>();

        points.Add(end);
        points.Add(pa);
        points.Add(pb);
        points.Add(start);

        mesh.SetVertices(points);

        mesh.triangles = new int[] { 1, 0, 2, 1, 2, 3 };

        mesh.RecalculateNormals();

        mesh.RecalculateNormals();

        GetComponent<MeshFilter>().mesh = mesh;

    }
    Vector2 startp;

    void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //    startp = Input.mousePosition;
        //if (Input.GetMouseButtonUp(0))
        //    DrawAngle(startp, Input.mousePosition);



        if (Input.GetMouseButtonDown(0))
            rect.position = Input.mousePosition;
        if (Input.GetMouseButton(0))
        {
            rect.size = (Vector2)Input.mousePosition - rect.position;
            //print(rect.size + "#" + rect.position);
            rectangle.ApplyData(rect);
        }




        //if (Input.GetKeyDown(KeyCode.Space))
        //{

        //    Mesh mesh = new Mesh();
        //    mesh.name = "new triangle";

        //    mesh.Clear();
        //    List<Vector3> points = new List<Vector3>();

        //    //Vector3[] points = new Vector3[3];
        //    points.Add(new Vector3(0, 0, 0));
        //    points.Add(new Vector3(5, 18, 1));
        //    //points.Add(new Vector3(5, 16, -1));
        //    //points.Add(new Vector3(10, 18, -1));
        //    points.Add(new Vector3(10, 16, 1));
        //    points.Add(new Vector3(0, 25, 0));
        //    points.Add(new Vector3(-10, 16, 1));
        //    //points.Add(new Vector3(-10, 18, -1));
        //    //points.Add(new Vector3(-5, 16, -1));
        //    points.Add(new Vector3(-5, 18, 1));

        //    //points.Add(new Vector3());

        //    mesh.SetVertices(points);


        //    mesh.triangles = new int[] { 1, 0, 5, 3, 2, 1, 5, 4, 3, 3, 1, 5 };
        //    //mesh.triangles = new int[] { 0, 1, 2, 1, 2, 3, 2, 3, 4, 3, 4, 5, 4, 5, 6, 5, 6, 7, 6, 7, 8, 7, 8, 9, 8, 9, 0 };
        //    //mesh.triangles[0] = 0;
        //    //mesh.triangles[1] = 1;
        //    //mesh.triangles[2] = 2;

        //    mesh.RecalculateNormals();


        //    //Mesh mesh = new Mesh();
        //    //mesh.name = "testMesh";
        //    //mesh.Clear();
        //    //mesh.vertices = new Vector3[4];
        //    //mesh.vertices[0].x = -10; mesh.vertices[0].y = 0; mesh.vertices[0].z = 0;
        //    //mesh.vertices[1].x = 10; mesh.vertices[1].y = 0; mesh.vertices[1].z = 0;
        //    //mesh.vertices[2].x = -10; mesh.vertices[2].y = 50; mesh.vertices[2].z = 0;
        //    //mesh.vertices[3].x = 10; mesh.vertices[3].y = 50; mesh.vertices[3].z = 0;

        //    //mesh.uv = new Vector2[4];
        //    //mesh.uv[0].x = 0; mesh.uv[0].y = 0;
        //    //mesh.uv[1].x = 1; mesh.uv[1].y = 0;
        //    //mesh.uv[2].x = 0; mesh.uv[2].y = 1;
        //    //mesh.uv[3].x = 1; mesh.uv[3].y = 1;

        //    //mesh.triangles = new int[6];
        //    //mesh.triangles[0] = 0;
        //    //mesh.triangles[1] = 1;
        //    //mesh.triangles[2] = 2;
        //    //mesh.triangles[3] = 1;
        //    //mesh.triangles[4] = 3;
        //    //mesh.triangles[5] = 2;

        //    mesh.RecalculateNormals();

        //    GetComponent<MeshFilter>().mesh = mesh;

        //}
    }
}
