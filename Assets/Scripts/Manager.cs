using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public bool gameStart = false;
    //NOTE: To get actual number of laps, devide totalLapCount by 2.
    public int totalLapCount = 8;
    GameObject player1, player2;
    bool waitWinner;

    void Start()
    {
        StartCoroutine(BeginCountdown());
        StartCoroutine(MusicCountdown());
        player1 = GameObject.FindGameObjectWithTag("Player1");
        player2 = GameObject.FindGameObjectWithTag("Player2");
        waitWinner = false;
    }

    void Update()
    {
        //Checks if the players have reached the lap amount and determines who the winner is.
        if (player1.GetComponent<Player_Manager>().currentLap == totalLapCount)
        {
            Debug.Log("PLAYER 1 WINS");
            gameStart = false;
            GameObject.Find("Canvas").GetComponent<UIManager>().UpdateWinner(player1);
            StartCoroutine(Winner());
            if(waitWinner)
                SceneManager.LoadScene(0, LoadSceneMode.Single);
        }
        if(player2.GetComponent<Player_Manager>().currentLap == totalLapCount)
        {
            Debug.Log("PLAYER 2 WINS");
            gameStart = false;
            GameObject.Find("Canvas").GetComponent<UIManager>().UpdateWinner(player2);
            StartCoroutine(Winner());
            if(waitWinner)
                SceneManager.LoadScene(0, LoadSceneMode.Single);
        }


    }

    //Waiting for the race to start. Will wait for three seconds.
    IEnumerator BeginCountdown()
    {
        yield return new WaitForSeconds(3);
        gameStart = true;
    }

    IEnumerator MusicCountdown()
    {
        yield return new WaitForSeconds(4);
        GameObject.Find("BackgroundMusic").GetComponent<AudioSource>().Play();
    }

    IEnumerator Winner()
    {
        GameObject.Find("WinnerAudio").GetComponent<AudioSource>().volume = 0.25f;
        GameObject.Find("BackgroundMusic").GetComponent<AudioSource>().Stop();
        yield return new WaitForSeconds(5);
        waitWinner = true;
    }
}
