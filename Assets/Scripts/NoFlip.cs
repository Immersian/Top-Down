using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoFlip : MonoBehaviour
{
    // Set this variable to true if you want to prevent flipping on the X-axis
    public bool preventXFlip = true;

    // Set this variable to true if you want to prevent flipping on the Y-axis
    public bool preventYFlip = true;

    // Reference to the GameObject to which you want to apply the no-flip behavior
    public GameObject targetObject;

    void Update()
    {
        // Check if a target object is assigned
        if (targetObject == null)
        {
            Debug.LogError("Target object is not assigned!");
            return;
        }

        // Get the current rotation of the target object
        Vector3 currentRotation = targetObject.transform.rotation.eulerAngles;

        // Check and constrain the rotation on the X-axis
        if (preventXFlip)
        {
            currentRotation.x = Mathf.Clamp(currentRotation.x, 0f, 0f);
        }

        // Check and constrain the rotation on the Y-axis
        if (preventYFlip)
        {
            currentRotation.y = Mathf.Clamp(currentRotation.y, 0f, 0f);
        }

        // Apply the constrained rotation back to the target object
        targetObject.transform.rotation = Quaternion.Euler(currentRotation);
    }
}


