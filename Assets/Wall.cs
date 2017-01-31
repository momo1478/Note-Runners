﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour {

    public float HoopCenter = 2f; //Centered from -0.5-4.5
    public float HoopRange = 1f;  //Symmetrical Note Leniency 

	// Use this for initialization
	void Start () 
    {
        transform.position = new Vector3(transform.position.x, HoopCenter/2, transform.position.z);

        //Bottom Wall
        transform.GetChild(0).localPosition = new Vector3(transform.position.x, transform.GetChild(0).position.y - (HoopRange / 2), transform.position.z);
        
        //Top Wall
        transform.GetChild(1).localPosition = new Vector3(transform.position.x, transform.GetChild(1).position.y + (HoopRange / 2), transform.position.z);
	}
	
	// Update is called once per frame
	void Update () 
    {
		
	}
}
