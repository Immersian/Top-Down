using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool Paused = false;
    public GameObject PauseMenuCanvas;
    public GameObject Player;
    public GameObject Aim;
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
        PauseMenuCanvas.SetActive(true);
        Player.SetActive(false);
        Aim.SetActive(false);
        Time.timeScale = 0.0f;
        Paused = true;
    }
    void Play()
    {
        PauseMenuCanvas.SetActive(false);
        Player.SetActive(true);
        Aim.SetActive(true);
        Time.timeScale = 1f;
        Paused = false;
    }
}
