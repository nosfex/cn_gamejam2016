﻿using UnityEngine;
using System.Collections;

public class EventManager : MonoBehaviour

{
    public delegate void MoveAction(int direction, int id);
    public static event MoveAction moveAction;

    public delegate void JumpAction(int id);
    public static event JumpAction jumpAction;

    public delegate void SpecialAction(int id);
    public static event SpecialAction specialAction;

    public static bool inputEnabled = false;

    public static float time = 10.0f;


    public GameObject[] destructables;

    public static int destroyedObjs = 0;
    public static bool gameFinished = false;
    public static bool StevenWon = false;
    // Use this for initialization
    void Start ()
    {
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (inputEnabled == false)
            return;
        if (gameFinished)
            return;
        time -= Time.deltaTime;

        if (time <= 0)
        {
            foreach (GameObject go in destructables)
            {
                BasicObject bo = go.GetComponent<BasicObject>();
                if(bo.broken)
                    destroyedObjs++;
            }
            if (destroyedObjs < destructables.Length / 2) StevenWon = true;

            gameFinished = true;


        }
        if (Input.GetAxis("Horizontal") <= -1)
        {
            moveAction(-1, 0);
        }

        if (Input.GetAxis("Horizontal") >= 1)
        {
            moveAction(1, 0);
        }

        if (Input.GetAxis("h2") <= -1)
        {
            moveAction(-1, 1);
        }

        if (Input.GetAxis("h2") >= 1)
        {
            moveAction(1, 1);
        }


        if(Input.GetAxis("Fire2") >= 1)
        {
            jumpAction(0);
        }

        if (Input.GetAxis("Fire1") <= -1)
        {
            jumpAction(1);
        }
        
        if (Input.GetKey(KeyCode.Joystick1Button4))
        {
            specialAction(0);
        }
        if (Input.GetKey(KeyCode.Joystick1Button5))
        {
            specialAction(1);
        }
    }
}
