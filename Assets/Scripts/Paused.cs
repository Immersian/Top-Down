using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool Paused = false;
    public GameObject PauseMenuCanvas;
    public GameObject Player;
    public GameObject Aim;
    public GameObject LevelFade;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Paused)
            {
                Play();
            }
            else
            {
                Stop();
            }

        }
    }
    void Stop()
    {
        LevelFade.SetActive(false);
        PauseMenuCanvas.SetActive(true);
        Player.SetActive(false);
        Aim.SetActive(false);
        Time.timeScale = 0.0f;
        Paused = true;
    }
    public void Play()
    {
        LevelFade.SetActive(true);
        PauseMenuCanvas.SetActive(false);
        Player.SetActive(true);
        Aim.SetActive(true);
        LevelFade.SetActive(false);
        Time.timeScale = 1f;
        Paused = false;

    }
}
