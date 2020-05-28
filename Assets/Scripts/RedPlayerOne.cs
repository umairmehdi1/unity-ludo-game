using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedPlayerOne : MonoBehaviour {


    public static string redPlayerOneColName;

    void OnTriggerEnter2D(Collider2D col) 
    {
        if (col.gameObject.tag == "Blocks")
        {
            redPlayerOneColName = col.gameObject.name;

            if (col.gameObject.name.Contains("Red House")) { }
        }
    }



	// Use this for initialization
	void Start(){

        redPlayerOneColName = "none";
	}
	
	
}
