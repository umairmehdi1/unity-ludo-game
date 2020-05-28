using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenPlayerThree : MonoBehaviour {


    public static string greenPlayerThreeColName;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Blocks")
        {
            greenPlayerThreeColName = col.gameObject.name;

            if (col.gameObject.name.Contains("Green House")) { }
        }
    }



    // Use this for initialization
    void Start()
    {

        greenPlayerThreeColName = "none";
    }
}
