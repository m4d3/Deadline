using UnityEngine;
using System.Collections;

public class StartScreen : MonoBehaviour {

    public bool showStartScreen;
    bool player1Ready;
    bool player2Ready;

	// Use this for initialization
	void Start () {
        //Time.timeScale = 0;
        showStartScreen = true;
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void Player1Ready()
    {
        player1Ready = true;
        
        //change graphic of one child (x to v)
    }
    public void Player2Ready()
    {
        player2Ready = true;

        //change graphic of one child (x to v)
    }
}
