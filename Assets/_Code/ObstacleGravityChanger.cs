using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGravityChanger : MonoBehaviour
{
    public int extraGravity = 10;
    private void OnTriggerEnter(Collider other)
    {
        var otherCf = other.GetComponent<ConstantForce>();
        otherCf.force = new Vector3(0, -extraGravity, 0);
    }

    private void OnTriggerExit(Collider other)
    {
        var otherCf = other.GetComponent<ConstantForce>();
        otherCf.force = new Vector3(0, 0, 0);
    }
}
