using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact_range : MonoBehaviour
{
    public GameObject interactUI;
    public GameObject Player;
    public GameObject teleportTarget;
    public GameObject grid;
    public GameObject npc;
    public GameObject Fade;

    private bool isInTeleportationZone = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isInTeleportationZone)
        {
            teleport();
            Destroy(npc);
            Destroy(Fade);
            grid.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            interactUI.SetActive(true);
            isInTeleportationZone = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            interactUI.SetActive(false);
            isInTeleportationZone = false;
        }
    }

    private void teleport()
    {
        Player.transform.position = teleportTarget.transform.position;
    }
}




