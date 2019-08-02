using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class SceneLoader : MonoBehaviour
{
    int resetBankedTime = 0;
    int currentSceneIndex;
    Scene[] scenes;

 
    public void LoadStartMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadNextScene()
    { 
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
    public void LoadGame()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadGameOver()
    {

        SceneManager.GetSceneByName("Game Over");
        SceneManager.LoadScene("Game Over");
    }

    public void LoadHowToPlayScene()
    {
        SceneManager.GetSceneByName("How To Play");
        SceneManager.LoadScene("How To Play");
    }


    public void QuitGame()
    {
        Application.Quit();
    }

    

}
