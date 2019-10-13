using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public bool gameStart = false;

    void Start()
    {
        StartCoroutine(BeginCountdown());
        Debug.Log("HELLO");
    }

    IEnumerator BeginCountdown()
    {
        yield return new WaitForSeconds(3);
        gameStart = true;
    }
}
