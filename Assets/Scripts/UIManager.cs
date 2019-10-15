using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    GameObject playerOne, playerTwo;
    void Start()
    {
        playerOne = GameObject.Find("PlayerOneSpr");
        playerTwo = GameObject.Find("PlayerTwoSpr");
    }

    //Checks if the players currently have a boost they can use by checking if hasboost == true
    //If it is true then the canvas will display boost ready and if not then no boost.
    void Update()
    {
        if (playerOne.GetComponent<Player_Manager>().hasBoost)
            GameObject.Find("Player1_Boost").GetComponent<Text>().text = "Boost Ready";
        else
            GameObject.Find("Player1_Boost").GetComponent<Text>().text = "No Boost";

        if (playerTwo.GetComponent<Player_Manager>().hasBoost)
            GameObject.Find("Player2_Boost").GetComponent<Text>().text = "Boost Ready";
        else
            GameObject.Find("Player2_Boost").GetComponent<Text>().text = "No Boost";
    }
    
    //Updates the laps text in the canvas
    //Works by taking the players current lap counter in Player_manager and dividing it by 2, then adding 1 to get the correct lap count.
    public void UpdateLaps(GameObject player)
    {
        if(player.name == "PlayerOneSpr")
            GameObject.Find("Player1_Lap").GetComponent<Text>().text = ((player.GetComponent<Player_Manager>().currentLap/  2) + 1).ToString();
        if (player.name == "PlayerTwoSpr")
            GameObject.Find("Player2_Lap").GetComponent<Text>().text = ((player.GetComponent<Player_Manager>().currentLap / 2) + 1).ToString();
    }

    //Updates the canvas to display who the winner of the race was via the passed parameter.
    public void UpdateWinner(GameObject player)
    {
        if (player.name == "PlayerOneSpr")
            GameObject.Find("WinnerText").GetComponent<Text>().text = "Player 1 Wins";
        else
            GameObject.Find("WinnerText").GetComponent<Text>().text = "Player 2 Wins";
    }
}
