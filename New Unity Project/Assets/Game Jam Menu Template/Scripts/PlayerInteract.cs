using UnityEngine;
using System.Collections;

public class PlayerInteract : MonoBehaviour {


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	
	
	}
	void OnCollisionEnter (Collision col)
	{

		Debug.Log (" toque algo ");
		if(col.gameObject.tag=="object")
		{
			col.gameObject.GetComponent<BasicObject> ().BreakObject ();
		}
	}


}
