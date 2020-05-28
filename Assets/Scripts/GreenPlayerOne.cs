using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenPlayerOne : MonoBehaviour {


    public static string greenPlayerOneColName;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Blocks")
        {
            greenPlayerOneColName = col.gameObject.name;

            if (col.gameObject.name.Contains("Green House")) { }
        }
    }



    // Use this for initialization
    void Start()
    {

        greenPlayerOneColName = "none";
    }
}
