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
        //gameStart is to disable the player controls and the movement.
        if (player1.GetComponent<Player_Manager>().currentLap == totalLapCount)
        {
            gameStart = false;
            GameObject.Find("Canvas").GetComponent<UIManager>().UpdateWinner(player1);
            StartCoroutine(Winner());
            if(waitWinner)
                SceneManager.LoadScene(0, LoadSceneMode.Single);
        }
        if(player2.GetComponent<Player_Manager>().currentLap == totalLapCount)
        {
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

    //Waits for 4 seconds before the background music begins, to allow the countdown sound to finish first
    IEnumerator MusicCountdown()
    {
        yield return new WaitForSeconds(4);
        GameObject.Find("BackgroundMusic").GetComponent<AudioSource>().Play();
    }

    //Mutes the background music and ups the volume for the winner music.
    //Sets the canvas text to display who the winner was and waits for 5 seconds before returning to the main menu.
    IEnumerator Winner()
    {
        GameObject.Find("WinnerAudio").GetComponent<AudioSource>().volume = 0.25f;
        GameObject.Find("BackgroundMusic").GetComponent<AudioSource>().Stop();
        yield return new WaitForSeconds(5);
        waitWinner = true;
    }
}
