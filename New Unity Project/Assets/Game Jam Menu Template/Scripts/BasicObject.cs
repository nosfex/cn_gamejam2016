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


        anim.SetFloat("Speed", 1);
        

       

	}

	public void FixObject()
	{

		Debug.Log (" arregle ");

        anim.SetFloat("Speed", 0);



    }



	public void DestroyObject()
	{

		GameObject.Destroy (this.gameObject);

	}

}
