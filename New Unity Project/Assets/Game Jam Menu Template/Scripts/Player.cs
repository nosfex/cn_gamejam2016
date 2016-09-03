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

    [Header("Salto")]
    public float fuerzaDeSalto = 20;
    public float gravedad = 100;
    public bool yDelPisoAutomatica = true;
    public float yDelPisoAMano = 185;
    float yDelPisoSupongo = -1;//Lo agarro en base al start (podria ser una variable publica y ya)
    float velocidadY = 0;

    public void moveX(int dir, int id)
    {
        if (id != playerID)
            return;
        direction = dir;
        //towards = new Vector3(transform.position.x  + ((moveDir.x * moveScale * direction) * (initFrictionCoef + curFriction) ), transform.position.y, transform.position.z);
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
        Debug.Log("jump "+id);
        if (this.playerID != id)
            return;
        if (stunned)
        {
            //Nada supongo?
        }
        else
        {
            if (transform.position.y <= yDelPisoSupongo)
            {//Es como que, desconfio de el orden en que se ejecutan los eventos y las cosas
                transform.position = new Vector3(transform.position.x,
                    yDelPisoSupongo, transform.position.z);
                towards.y = transform.position.y;
                velocidadY = fuerzaDeSalto;
            }
        }
    }

    public void stun()
    { 

        
        if(stunned == false && currStun <= 0.0f)
            stunned = true;
    }

    void specialAction(int id)
    {
        if (id == playerID && playerID == 0)
        {
            Debug.Log("pokerat");
        }
    }

    void stompBreak()
    {

    }

    void lickFix()
    {
    }
    // Use this for initialization
	void Start ()
    {
        towards = this.transform.position;
        EventManager.moveAction += moveX;

        EventManager.jumpAction += jump;

        EventManager.specialAction += specialAction;

        if (yDelPisoAutomatica) yDelPisoSupongo = transform.position.y;
        else yDelPisoSupongo = yDelPisoAMano;
	}

    void ActualizarMovidasDeSalto()
    {
        transform.position = transform.position +
            Vector3.up * velocidadY * Time.deltaTime;
        towards.y = transform.position.y;
        if (transform.position.y <= yDelPisoSupongo)
        {
            transform.position = new Vector3(transform.position.x,
                yDelPisoSupongo, transform.position.z);
            towards.y = transform.position.y;
            velocidadY = 0;
        }
        else
        {
            velocidadY -= gravedad * Time.deltaTime;
        }
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
        towards = new Vector3(((moveDir.x * moveScale * direction)  + slideX ) * Time.deltaTime, towards.y, towards.z);

        // Gh: Move this actor
        this.transform.position = new Vector3(this.transform.position.x +  towards.x, this.transform.position.y, this.transform.position.z);

        ActualizarMovidasDeSalto();
        direction = 0;
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
        }
    }
}
