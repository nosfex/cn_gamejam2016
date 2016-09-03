using UnityEngine;
using System.Collections;

public class PlayerInteract : MonoBehaviour {


    public int playerID;


	// Use this for initialization
	void Start () {

        playerID = gameObject.GetComponent<Player>().playerID;
	
	}
	
	// Update is called once per frame
	void Update () {

	
	
	}
	void OnCollisionEnter2D (Collision2D col)
	{

		Debug.Log (" toque algo ");
		if(col.gameObject.tag=="Object")
		{
            if (playerID==1) {

                col.gameObject.GetComponent<BasicObject>().BreakObject();

            } else if (playerID == 0) {

                col.gameObject.GetComponent<BasicObject>().FixObject();
            }
		
		}
	}


}
