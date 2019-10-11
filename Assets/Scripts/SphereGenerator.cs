﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereGenerator : MonoBehaviour {

    public void CreateFallingSphere()
    {
        GameObject go = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        go.transform.position = new Vector3(0, 10, 0);
        go.AddComponent<Rigidbody>();
    }
}
