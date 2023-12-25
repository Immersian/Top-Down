using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public TMP_Text timerText;
    public float totalTime = 60f; // Set the total time for the timer in seconds
    private float currentTime;
    public GameObject NPC;
    public GameObject Spawner1;
    public GameObject Spawner2;
    public GameObject Grid;
    public GameObject timer;
    void Start()
    {
        currentTime = totalTime;
    }

    void Update()
    {
        if (NPC == null)
        {
            if (currentTime > 0)
            {
                currentTime -= Time.deltaTime;
                UpdateTimerText();
            }
            else
            {
                // Timer has reached zero, you can perform any actions here
                Debug.Log("Time's up!");
                Destroy(Spawner1);
                Destroy(Spawner2);
                Grid.SetActive(true);
                Destroy(timer);
            }
        }
    }

    void UpdateTimerText()
    {
        // Format the time as minutes and seconds
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);

        // Update the UI text
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}


