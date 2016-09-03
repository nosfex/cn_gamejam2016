using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameClock : MonoBehaviour
{
    Text timer;
	// Use this for initialization
	void Start ()
    {
        timer = this.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (EventManager.inputEnabled)
        {
            timer.text = Mathf.Ceil(EventManager.time).ToString();
        }
	}
}
