using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

    public float distance;
    public float height;
    public GameObject objectToFollow;


    // After all Update function when been called once per frame
    void LateUpdate()
    {
        if(objectToFollow == null)
            return;

        Vector3 destination = objectToFollow.transform.position;
        destination.x = 50.2f;
        destination.y += height;
        destination.z += distance;

        transform.position = destination;
    }
}
