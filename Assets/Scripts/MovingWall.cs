using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWall : MonoBehaviour
{
    public float wallSpeed = 0.5f;

    void Update()
    {
        transform.position += transform.up * Time.deltaTime * wallSpeed;
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Wall")
            transform.Rotate(0, 0, 180.0f);
    }
}
