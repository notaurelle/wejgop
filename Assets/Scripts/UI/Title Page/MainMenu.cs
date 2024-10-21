using System.Collections;

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public PlayerInput[] players; 

  public void PlayCutscene()
    {
        // loads scenes in order within the build settings
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Level_01");

        //foreach(PlayerInput p in players)
        //{
        //    p.canMove = true; 
        //}

    }




}
