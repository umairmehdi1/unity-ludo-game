using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePlayerFour : MonoBehaviour {

    public static string bluePlayerFourColName;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Blocks")
        {
            bluePlayerFourColName = col.gameObject.name;

            if (col.gameObject.name.Contains("Blue House")) { }
        }
    }



    // Use this for initialization
    void Start()
    {

        bluePlayerFourColName = "none";
    }
}
