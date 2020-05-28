using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedPlayerThree : MonoBehaviour {

    public static string redPlayerThreeColName;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Blocks")
        {
            redPlayerThreeColName = col.gameObject.name;

            if (col.gameObject.name.Contains("Red House")) { }
        }
    }



    // Use this for initialization
    void Start()
    {

        redPlayerThreeColName = "none";
    }
}
