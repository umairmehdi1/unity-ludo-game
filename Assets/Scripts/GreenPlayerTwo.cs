using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenPlayerTwo : MonoBehaviour {

    public static string greenPlayerTwoColName;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Blocks")
        {
            greenPlayerTwoColName = col.gameObject.name;

            if (col.gameObject.name.Contains("Green House")) { }
        }
    }



    // Use this for initialization
    void Start()
    {

        greenPlayerTwoColName = "none";
    }
}
