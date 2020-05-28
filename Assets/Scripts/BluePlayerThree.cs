using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePlayerThree : MonoBehaviour {

    public static string bluePlayerThreeColName;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Blocks")
        {
            bluePlayerThreeColName = col.gameObject.name;

            if (col.gameObject.name.Contains("Blue House")) { }
        }
    }



    // Use this for initialization
    void Start()
    {

        bluePlayerThreeColName = "none";
    }
}
