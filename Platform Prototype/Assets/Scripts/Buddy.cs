﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buddy : MonoBehaviour
{
    public float xOffset = 1f;
    public float InterpolationFactor = 0.05f;

    PitchTester pt;
    GameController gc;

    SpriteRenderer spriteRenderer;
    Transform playerTransform;

    TrailRenderer trailRenderer;

    Color startGoal, endGoal = Color.black;

    string lastNote;
	// Use this for initialization
	void Start ()
    {
        pt = GameObject.Find("Pitch Tester").GetComponent<PitchTester>();
        gc = GameObject.Find("Game Controller").GetComponent<GameController>();

        spriteRenderer = GetComponent<SpriteRenderer>();
        playerTransform = GameObject.Find("Player").GetComponent<Transform>();

        trailRenderer = GetComponent<TrailRenderer>();
        trailRenderer.startColor = Color.black;
        trailRenderer.endColor = Color.white;
    }
	
	// Update is called once per frame
	void Update ()
    {
        spriteRenderer.color = Random.ColorHSV();

        //Remove this line for buddy trail effect. Buddy will struggle to catch up to the player as the player moves faster. Keep this line to lock at xOffset.
        //transform.position = new Vector3(playerTransform.position.x + xOffset, transform.position.y, 0f);

        Vector3 targetPos;
        if (!string.IsNullOrEmpty(pt.MainNote))
        {
            string currentNote = pt.MainNote;
            if(lastNote != currentNote)
            {
                endGoal = trailRenderer.startColor;
                startGoal = gc.noteColorLookup[currentNote];

                lastNote = currentNote;
            }

            trailRenderer.endColor = Color.Lerp(trailRenderer.endColor, endGoal, 0.05f);
            trailRenderer.startColor = Color.Lerp(trailRenderer.startColor, startGoal, 0.05f);

            targetPos = new Vector3(playerTransform.position.x + xOffset, gc.notePosLookup[currentNote], 0f);
        }
        else
        {
            targetPos = new Vector3(playerTransform.position.x + xOffset, transform.position.y, 0f);
            //transform.Rotate(new Vector3(0, 0, transform.position.y * 15)); Monish's dream is dead.
            
        }

        transform.position = Vector3.Lerp(transform.position, targetPos, InterpolationFactor);
    }
}
