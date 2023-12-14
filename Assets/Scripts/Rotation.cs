using UnityEngine;

public class Rotation : MonoBehaviour
{
    public float rotationOffset = 90.0f; // Offset rotation to align with the gun's direction
    public Transform player; // Reference to the player's Transform

    // Update is called once per frame
    void Update()
    {
        // Get the World position of the mouse
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = 0f; // Ensure the same Z position as the player

        // Calculate the direction from the player to the mouse
        Vector3 directionToMouse = mouseWorldPosition - player.position;

        // Calculate the rotation angle in degrees
        float angle = Mathf.Atan2(directionToMouse.y, directionToMouse.x) * Mathf.Rad2Deg;

        // Apply the offset to the rotation
        transform.rotation = Quaternion.Euler(0f, 0f, angle + rotationOffset);
    }
}






