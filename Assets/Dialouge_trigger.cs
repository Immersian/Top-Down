using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialouge_trigger : MonoBehaviour
{
    public GameObject interactUI;
    public GameObject Player;
    public Dialogue dialogueScript;
    public Movement movement;
    public GameObject Interact;

    private bool isPickUpZone = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isPickUpZone)
        {
            dialogueScript.StartDialogue();

            movement.enabled = false;

            Interact.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            interactUI.SetActive(true);
            isPickUpZone = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            interactUI.SetActive(false);
            isPickUpZone = false;
        }
    }
}

