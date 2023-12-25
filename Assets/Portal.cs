using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public GameObject Boss;
    public GameObject Grid;

    void Start()
    {
        if (Grid == null)
        {
            Debug.LogError("Grid GameObject is not assigned!");
        }
        else
        {
            Grid.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Boss == null)
        {
            Debug.Log("Boss is destroyed!");

            if (Grid != null)
            {
                Grid.SetActive(true);
            }
            else
            {
                Debug.LogError("Grid GameObject is not assigned!");
            }
        }
    }
}

