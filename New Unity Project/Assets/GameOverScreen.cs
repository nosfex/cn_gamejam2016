using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class GameOverScreen : MonoBehaviour {
    Text timer;
    // Use this for initialization
    void Start()
    {
        timer = this.GetComponent<Text>();
    }
  
	// Update is called once per frame
	void Update () {
        if (EventManager.gameFinished)
        {
            if (EventManager.StevenWon)
            {
                timer.text = "GANO STEVEN";
            }
            else
            {
                timer.text = "GANO AMETHYST";
            }
        }
	}
}
