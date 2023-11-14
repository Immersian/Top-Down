using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Interact_range : MonoBehaviour
{
    public GameObject interactUI;
    public GameObject Player;
    public GameObject teleportTarget;
    public GameObject grid;
    public GameObject npc;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            teleport();
            npc.SetActive(false);
            grid.SetActive(false);

        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            interactUI.SetActive(true);
            
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            interactUI.SetActive(false);
        }
    }
    private void teleport()
    {

        Player.transform.position = teleportTarget.transform.position;

    }
}
    


