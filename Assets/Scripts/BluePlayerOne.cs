using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePlayerOne : MonoBehaviour {

    public static string bluePlayerOneColName;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Blocks")
        {
            bluePlayerOneColName = col.gameObject.name;

            if (col.gameObject.name.Contains("Blue House")) { }
        }
    }



    // Use this for initialization
    void Start()
    {

        bluePlayerOneColName = "none";
    }
}
