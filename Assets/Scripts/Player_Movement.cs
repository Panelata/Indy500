﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public float movementSpeed = 1.0f;

    void Start()
    {
        //gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
    }

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
            }
            else
            {
                if (Input.GetKey(KeyCode.RightArrow))
                    RotateClockwise();

                if (Input.GetKey(KeyCode.LeftArrow))
                    RotateCounterClockwise();
            }
        }
    }

    //Detects when the player hits a wall, and resets the player to a position just before they hit the wall.
    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Wall" || col.gameObject.tag == "MovingWall")
        {
            movementSpeed = movementSpeed / 2;
            transform.position -= transform.up;
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
