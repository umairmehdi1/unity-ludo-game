using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowPlayerFour : MonoBehaviour {

    public static string yellowPlayerFourColName;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Blocks")
        {
            yellowPlayerFourColName = col.gameObject.name;

            if (col.gameObject.name.Contains("Yellow House")) { }
        }
    }



    // Use this for initialization
    void Start()
    {

        yellowPlayerFourColName = "none";
    }
}
