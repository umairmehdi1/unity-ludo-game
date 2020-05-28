using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenPlayerFour : MonoBehaviour {

    public static string greenPlayerFourColName;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Blocks")
        {
            greenPlayerFourColName = col.gameObject.name;

            if (col.gameObject.name.Contains("Green House")) { }
        }
    }



    // Use this for initialization
    void Start()
    {

        greenPlayerFourColName = "none";
    }
}
