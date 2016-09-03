using UnityEngine;
using System.Collections;

public class EventManager : MonoBehaviour

{
    public delegate void MoveAction(int direction, int id);
    public static event MoveAction moveAction;

    public delegate void JumpAction(int id);
    public static event JumpAction jumpAction;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {

        Debug.Log(Input.GetAxis("Horizontal").ToString());
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
    }
}
