using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWall : MonoBehaviour
{
    public float wallSpeed = 0.5f;

    //Moves the wall
    void Update()
    {
        transform.position += transform.up * Time.deltaTime * wallSpeed;
    }

    //When the moving wall detects another wall, it will rotate 180 degrees and reverse direction
    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Wall")
            transform.Rotate(0, 0, 180.0f);
    }
}
