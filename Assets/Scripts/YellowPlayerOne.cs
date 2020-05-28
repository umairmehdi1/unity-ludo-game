using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowPlayerOne : MonoBehaviour {

    public static string yellowPlayerOneColName;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Blocks")
        {
            yellowPlayerOneColName = col.gameObject.name;

            if (col.gameObject.name.Contains("Yellow House")) { }
        }
    }



    // Use this for initialization
    void Start()
    {

        yellowPlayerOneColName = "none";
    }
}
