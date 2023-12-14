using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedZPosition : MonoBehaviour
{
    public float fixedZPosition = 0f; // Set this to the desired fixed z-position

    // Update is called once per frame
    void Update()
    {
        // Get the current position
        Vector3 currentPosition = transform.position;

        // Set the z-position to the fixed value
        currentPosition.z = fixedZPosition;

        // Apply the updated position
        transform.position = currentPosition;
    }
}

