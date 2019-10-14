using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Manager : MonoBehaviour
{
    public float movementSpeed = 1.0f;
    //Note: One lap will count as 2 in backend, therefore totalLapCount / 2 will be the actual number of laps
    public int currentLap = -2;
    private bool hasBoost = false;

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Manager").GetComponent<Manager>().gameStart)
        {
            //constant movement of the players vehicle.
            movementSpeed += 0.1f * Time.deltaTime;
            transform.position += transform.up * Time.deltaTime * movementSpeed;

            //splits up the controls between player one and two.
            if (gameObject.name.Equals("PlayerOneSpr"))
            {
                if (Input.GetKey(KeyCode.D))
                    RotateClockwise();

                if (Input.GetKey(KeyCode.A))
                    RotateCounterClockwise();

                //Grants movement speed and removes the boost from the player.
                if (Input.GetKey(KeyCode.W) && hasBoost)
                {
                    movementSpeed += 1;
                    hasBoost = false;
                }
            }
            else
            {
                if (Input.GetKey(KeyCode.RightArrow))
                    RotateClockwise();

                if (Input.GetKey(KeyCode.LeftArrow))
                    RotateCounterClockwise();

                if (Input.GetKey(KeyCode.UpArrow) && hasBoost)
                {
                    movementSpeed += 1;
                    hasBoost = false;
                }
            }
        }
    }

    
    void OnTriggerEnter(Collider col)
    {
        //Detects when the player hits a wall, and resets the player to a position just before they hit the wall.
        if (col.gameObject.tag == "Wall" || col.gameObject.tag == "MovingWall")
        {
            movementSpeed = movementSpeed / 2.0f;
            transform.position -= transform.up * 0.05f;
        }
        //When a player passes the start/end sprite, it will up the lap counter and update the UI.
        if (col.gameObject.tag == "Lap")
        {
            currentLap += 2;
            GameObject.Find("Canvas").GetComponent<UIManager>().UpdateLaps(gameObject);
        }
        if(col.gameObject.tag == "Boost")
        {
            Destroy(col.gameObject);
            hasBoost = true;
        }
    }


    //Rotates the player
    void RotateClockwise()
    {
        transform.Rotate(0, 0, -150.0f * Time.deltaTime);
    }

    void RotateCounterClockwise()
    {
        transform.Rotate(0, 0, 150.0f * Time.deltaTime);
    }
    
}
