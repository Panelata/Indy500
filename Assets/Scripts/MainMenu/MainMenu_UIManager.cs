using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu_UIManager : MonoBehaviour
{
    //Quits the game
    public void QuitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }

    //The following methods will load the appropriate stage that the player chooses
    public void LoadStageOne()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    public void LoadStageTwo()
    {
        SceneManager.LoadScene(2, LoadSceneMode.Single);
    }

    public void LoadStageThree()
    {
        SceneManager.LoadScene(3, LoadSceneMode.Single);
    }
}
