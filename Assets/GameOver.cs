using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverUI;
    private bool isGameOver = false;
    public GameObject player;
    public GameObject pauseMenu;
    public GameObject Spawner1;
    public GameObject Spawner2;
    public GameObject Base;
    public GameObject Timer;
    // Start is called before the first frame update
    void Start()
    {
        gameOverUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameOver)
        {
            if (player == null || Base == null)
            {
                ShowGameOverUI();
            }
        }
    }
    private void ShowGameOverUI()
    {
        isGameOver = true;

        gameOverUI.SetActive(true);

        pauseMenu.SetActive(false);

        Timer.SetActive(false);

        Time.timeScale = 0f;
        Destroy(Spawner1);
        Destroy(Spawner2);
    }
}
