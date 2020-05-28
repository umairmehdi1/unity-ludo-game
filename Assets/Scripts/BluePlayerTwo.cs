using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePlayerTwo : MonoBehaviour {

    public static string bluePlayerTwoColName;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Blocks")
        {
            bluePlayerTwoColName = col.gameObject.name;

            if (col.gameObject.name.Contains("Blue House")) { }
        }
    }



    // Use this for initialization
    void Start()
    {

        bluePlayerTwoColName = "none";
    }
}
