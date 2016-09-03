using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

    public int playerID = 0;
    public float moveScale = 1.0f;
    Vector3 moveDir = Vector3.right;


    float initFrictionCoef = 0.15f;
    float curFriction = 0.0f;
    public float frictionScalar = 0.21f;

    float slideX = 0.0f;
    public float slideCoef = 0.00833f;
    Vector3 towards;


    int direction = 0;
    public void moveX(int dir, int id)
    {
        if (id != playerID)
            return;
        direction = dir;
        towards = new Vector3(transform.position.x  + ((moveDir.x * moveScale * direction) * (initFrictionCoef + curFriction) ), transform.position.y, transform.position.z);
        curFriction += Time.deltaTime * frictionScalar;


        slideX = 0;
        
        slideCoef = 0.00833f;
    } 
    // Use this for initialization
	void Start ()
    {
        towards = this.transform.position;
        EventManager.moveAction += moveX;
	}
	
	// Update is called once per frame
	void Update ()
    {
        towards = new Vector3(towards.x + slideX, towards.y, towards.z);
        this.transform.position = Vector3.MoveTowards(this.transform.position, towards, 0.359f);

        slideX = direction *  slideCoef;
        slideCoef -= Time.deltaTime * (0.0053f) ;
        curFriction -= Time.deltaTime * (frictionScalar / 2);

        if (curFriction <= 0) curFriction = 0;
        if (slideCoef <= 0) slideCoef = 0;
    }


    void OnCollisionEnter2D(Collision2D coll)
    {
        Debug.Log("shit colliding");
    }
}
