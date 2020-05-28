using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowPlayerThree : MonoBehaviour {

    public static string yellowPlayerThreeColName;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Blocks")
        {
            yellowPlayerThreeColName = col.gameObject.name;

            if (col.gameObject.name.Contains("Yellow House")) { }
        }
    }



    // Use this for initialization
    void Start()
    {

        yellowPlayerThreeColName = "none";
    }
}
