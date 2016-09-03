using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    // GH: Player id
    public int playerID = 0;
    // GH: scaling of movement
    public float moveScale = 1.0f;
    Vector3 moveDir = Vector3.right;

    // GH: Wonky physics
    float initFrictionCoef = 0.15f;
    float curFriction = 0.0f;
    public float frictionScalar = 0.21f;
    float slideX = 0.0f;
    public float slideCoef = 0.00833f;
    public float pushScale = 5.0f;
    // GH: Save movement
    public Vector3 towards;
    
    // GH: Move dir
    public int direction = 0;
    
    // GH: Stun logic
    bool stunned = false;
    public float maxStun = 1.0f;
    float currStun = 0.0f;
    public float stunInvulTime = 2.0f;
    //GH: movement callback
    public float pushInvulTime = 2.0f;
    bool pushed = false;
    
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

    public void push(int dir, int id)
    {

        if (pushed == true)
            return;
        towards = new Vector3(transform.position.x + (moveDir.x * pushScale *  dir), transform.position.y, transform.position.z);
        slideX = 0;
        pushed = true;
        slideCoef = 0.00833f;
    }

    public void jump(int id)
    {
        if (this.playerID != id)
            return;
    }

    public void stun()
    { 
        if(stunned == false && currStun <= 0.0f)
            stunned = true;
    }
    // Use this for initialization
	void Start ()
    {
        towards = this.transform.position;
        EventManager.moveAction += moveX;

        EventManager.jumpAction += jump;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (stunned)
        {
            currStun += Time.deltaTime;
            if (currStun >= maxStun) stunned = false;

            return;
        }

        if (pushed)
        {
            pushInvulTime -= Time.deltaTime;
            if (pushInvulTime <= 0.0f) pushed = false;
        }

        if (currStun >= 0.0f)
        {
            currStun -= Time.deltaTime;
        }
        // GH: recalculate towards with the slide
        towards = new Vector3(towards.x + slideX, towards.y, towards.z);

        // Gh: Move this actor
        this.transform.position = Vector3.MoveTowards(this.transform.position, towards, 0.359f);

        // GH: Modify the physics mods
        slideX = direction *  slideCoef;
        slideCoef -= Time.deltaTime * (0.0053f) ;
        curFriction -= Time.deltaTime * (frictionScalar / 2);

        // GH: Lazy clamp
        if (curFriction <= 0) curFriction = 0;
        if (slideCoef <= 0) slideCoef = 0;
    }


    void OnCollisionEnter2D(Collision2D coll)
    {
        Debug.Log("shit colliding");
        if (coll.gameObject.tag == "Player")
        {
            Player enemy = coll.gameObject.GetComponent<Player>();

            if (Mathf.Abs(this.towards.sqrMagnitude) < Mathf.Abs(enemy.towards.sqrMagnitude))
            {
                if (enemy.playerID == 0) enemy.push(direction, playerID);
                if (enemy.playerID == 1)
                    enemy.stun();
            }
        }
    }
}
