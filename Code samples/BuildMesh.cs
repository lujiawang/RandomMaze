using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildMesh : MonoBehaviour
{
    public Vector3 leftBottomFront = new Vector3(-0.5f, 0, -0.5f);
    public Vector3 rightBottomFront = new Vector3(0, 0, -0.25f);
    public Vector3 leftBottomBack = new Vector3(0, 0, 0.5f);
    public Vector3 rightBottomBack = new Vector3(0.5f, 0, -0.5f);

    public Vector3 leftTopFront = new Vector3(-0.5f, 1, -0.5f);
    public Vector3 rightTopFront = new Vector3(0, 1, -0.25f);    
    public Vector3 leftTopBack = new Vector3(0, 1, 0.5f);
    public Vector3 rightTopBack = new Vector3(0.5f, 1, -0.5f);
    

    // Start is called before the first frame update
    void Start()
    {
        

        MeshFilter mf = GetComponent<MeshFilter>();
        Mesh mesh = mf.mesh;

        Vector3[] vertices = new Vector3[]
        {
            //front 0,1,2,3
            leftBottomFront,
            leftTopFront,
            rightTopFront,
            rightBottomFront,

            //back 4,5,6,7
            leftBottomBack,
            leftTopBack,
            rightTopBack,
            rightBottomBack,

            //left 8,9,10,11
            leftBottomBack,
            leftTopBack,
            leftTopFront,
            leftBottomFront,

            //right 12,13,14,15
            rightBottomFront,
            rightTopFront,
            rightTopBack,
            rightBottomBack,

            //top 16,17,18,19
            leftTopFront,
            leftTopBack,
            rightTopBack,
            rightTopFront,

            //bottom 20,21,22,23
            leftBottomFront,
            leftBottomBack,
            rightBottomBack,
            rightBottomFront
        };

        int[] triangles = new int[]
        {
            //front
            0,1,2,
            2,3,0,

            //back
            7,6,5,
            5,4,7,

            //left
            8,9,10,
            10,11,8,

            //right
            12,13,14,
            14,15,12,

            //top
            16,17,19,
            19,17,18,

            //bottom
            23,22,21,
            21,20,23
        };

        Vector2[] uvs = new Vector2[]
        {
            //front
            new Vector2(0,1),
            new Vector2(0,0),
            new Vector2(1,1),
            new Vector2(1,0),

            new Vector2(0,1),
            new Vector2(0,0),
            new Vector2(1,1),
            new Vector2(1,0),

            new Vector2(0,1),
            new Vector2(0,0),
            new Vector2(1,1),
            new Vector2(1,0),

            new Vector2(0,1),
            new Vector2(0,0),
            new Vector2(1,1),
            new Vector2(1,0),

            new Vector2(0,1),
            new Vector2(0,0),
            new Vector2(1,1),
            new Vector2(1,0),

            new Vector2(0,1),
            new Vector2(0,0),
            new Vector2(1,1),
            new Vector2(1,0),
        };

        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uvs;
        mesh.RecalculateNormals();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
