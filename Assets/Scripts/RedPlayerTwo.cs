using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedPlayerTwo : MonoBehaviour {

    public static string redPlayerTwoColName;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Blocks")
        {
            redPlayerTwoColName = col.gameObject.name;

            if (col.gameObject.name.Contains("Red House")) { }
        }
    }



    // Use this for initialization
    void Start()
    {

        redPlayerTwoColName = "none";
    }
}
