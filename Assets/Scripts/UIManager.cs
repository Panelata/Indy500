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
    
    //Updates the laps text in the canvas
    //Works by taking the players current lap counter in Player_manager and dividing it by 2, then adding 1 to get the correct lap count.
    public void UpdateLaps(GameObject player)
    {
        if(player.name == "PlayerOneSpr")
            GameObject.Find("Player1_Lap").GetComponent<Text>().text = ((player.GetComponent<Player_Manager>().currentLap/  2) + 1).ToString();
        if (player.name == "PlayerTwoSpr")
            GameObject.Find("Player2_Lap").GetComponent<Text>().text = ((player.GetComponent<Player_Manager>().currentLap / 2) + 1).ToString();
    }
}
