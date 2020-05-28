using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowPlayerTwo : MonoBehaviour {

    public static string yellowPlayerTwoColName;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Blocks")
        {
            yellowPlayerTwoColName = col.gameObject.name;

            if (col.gameObject.name.Contains("Yellow House")) { }
        }
    }



    // Use this for initialization
    void Start()
    {

        yellowPlayerTwoColName = "none";
    }
}
