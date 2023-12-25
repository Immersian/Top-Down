using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedZRotation : MonoBehaviour
{
    public float fixedZRotation = 0f; // Set this to the desired fixed z-rotation

    // Update is called once per frame
    void Update()
    {
        // Get the current rotation
        Quaternion currentRotation = transform.rotation;

        // Set the z-rotation to the fixed value
        Quaternion fixedZQuaternion = Quaternion.Euler(0f, 0f, fixedZRotation);

        // Apply the updated rotation
        transform.rotation = fixedZQuaternion;
    }
}
