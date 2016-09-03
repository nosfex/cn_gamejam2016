using UnityEngine;
using System.Collections;

public class BasicObject : MonoBehaviour {

	Animator anim;
	int FixHash = Animator.StringToHash("Fix");
	int BreakHash = Animator.StringToHash("Break");

	// Use this for initialization
	void Start () {
	
		anim = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void BreakObject()
	{
		Debug.Log (" destrui ");

        
            anim.SetTrigger(BreakHash);
        

       

	}

	public void FixObject()
	{

		Debug.Log (" arregle ");
       
            anim.SetTrigger(FixHash);
        
		

	}



	public void DestroyObject()
	{

		GameObject.Destroy (this.gameObject);

	}

}
