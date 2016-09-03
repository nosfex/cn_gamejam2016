using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

    public int playerID = 0;
    public float moveScale = 1.0f;
    Vector3 moveDir = Vector3.right;

    Vector3 towards;
    public void moveX(int direction, int id)
    {
        if (id != playerID)
            return;
        towards = new Vector3(transform.position.x  + (moveDir.x * moveScale * direction), transform.position.y, transform.position.z);
    } 
    // Use this for initialization
	void Start ()
    {
        towards = this.transform.position;
        EventManager.moveAction += moveX;
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position = Vector3.MoveTowards(this.transform.position, towards, 0.59f);
	}
}
