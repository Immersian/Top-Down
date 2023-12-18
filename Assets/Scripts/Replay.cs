using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Replay : MonoBehaviour
{
    public GameObject PauseMenuCanvas;
    public static bool Paused = true;
    public GameObject Player;
    public GameObject Aim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Should Quit the game");

    }
    public void Resume()
    {
        PauseMenuCanvas.SetActive(false);
        Player.SetActive(true);
        Aim.SetActive(true);
        Time.timeScale = 1f;
        Paused = false;
    }
    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
}
