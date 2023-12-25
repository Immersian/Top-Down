using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public GameObject interactUI;
    public GameObject Player;

    private bool isPickUpZone = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isPickUpZone)
        {
            SceneManager.LoadScene("Level 2");
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