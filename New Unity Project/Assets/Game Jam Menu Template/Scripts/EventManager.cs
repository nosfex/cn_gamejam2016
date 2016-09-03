using UnityEngine;
using System.Collections;

public class EventManager : MonoBehaviour

{
    public delegate void MoveAction(int direction, int id);
    public static event MoveAction moveAction;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey(KeyCode.A))
        {
            moveAction(-1, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            moveAction(1, 0);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            moveAction(-1, 1);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            moveAction(1, 1);
        }
    }
}
