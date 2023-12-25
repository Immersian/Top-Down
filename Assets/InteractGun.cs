using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractGun : MonoBehaviour
{
    //public GameObject Weapon;
    public GameObject[] PickupFeedbacks;
    public LayerMask TargetLayerMask;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collided object's layer is in the TargetLayerMask
        if (!((TargetLayerMask.value & (1 << other.gameObject.layer)) > 0))
            return;

        PickedUp(other);

        foreach (var feedback in PickupFeedbacks)
        {
            if (feedback != null) // Check for null before instantiating
            {
                GameObject.Instantiate(feedback, transform.position, transform.rotation);
            }
        }

        // Prevent the Weapon object from being destroyed when the scene changes
        //DontDestroyOnLoad(Weapon);

        // Destroy the InteractGun object

        Debug.Log("Weapon equipped");

    }
    protected virtual void PickedUp(Collider2D collider)
    {

    }
}



