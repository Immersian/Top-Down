using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverLvl2 : MonoBehaviour
{
    public GameObject gameOverUI;
    private bool isGameOver = false;
    public GameObject player;
    public GameObject pauseMenu;
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
            if (player == null)
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
    }
}

