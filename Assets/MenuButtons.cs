using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{

        public void NextLevel()
        {
            SceneManager.LoadScene("Level 1");
        }
        public void QuitGame()
        {
            Application.Quit();
            Debug.Log("Game is exiting");
            //Just to make sure its working
        }
}
