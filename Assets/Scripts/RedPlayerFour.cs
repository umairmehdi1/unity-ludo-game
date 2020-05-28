using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedPlayerFour : MonoBehaviour {

    public static string redPlayerFourColName;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Blocks")
        {
            redPlayerFourColName = col.gameObject.name;

            if (col.gameObject.name.Contains("Red House")) { }
        }
    }



    // Use this for initialization
    void Start()
    {

        redPlayerFourColName = "none";
    }
}
