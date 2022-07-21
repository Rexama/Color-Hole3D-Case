using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnChangePosition : MonoBehaviour
{
    public PolygonCollider2D hole2DCollider;
    public PolygonCollider2D ground2DCollider;

    public MeshCollider generatedMeshCollider;
    private Mesh generatedMesh;

    private void FixedUpdate()
    {
        if (transform.hasChanged)
        {
            transform.hasChanged = false;
            var newPos = new Vector3(transform.position.x, transform.position.z);
            hole2DCollider.transform.position = newPos;
            MakeHole2D();
            Make3DMeshColider();
        }
    }

    private void MakeHole2D()
    {
        Vector2[] pointPositions = hole2DCollider.GetPath(0);
        for (int i = 0; i < pointPositions.Length; i++)
        {
            pointPositions[i] += (Vector2) hole2DCollider.transform.position;
        }

        ground2DCollider.pathCount = 2;
        ground2DCollider.SetPath(1, pointPositions);
    }

    private void Make3DMeshColider()
    {
        if (generatedMesh != null) Destroy(generatedMesh);

        generatedMesh = ground2DCollider.CreateMesh(true, true);
        generatedMeshCollider.sharedMesh = generatedMesh;
    }
}
