using UnityEngine;
using System.Collections;

public class Interface : MonoBehaviour {

	public PlayerCollision player1;
	public PlayerCollision player2;
    public PlayerPowerUps powerUps1;
    public PlayerPowerUps powerUps2;
	public GUISkin skin;

	public int winningCoins;

	bool showEndScreen = false;

    void Start()
    {
        //Time.timeScale = 1;
        showEndScreen = false;
    }

	void OnGUI() {

		GUI.skin = skin;		
		
        // Player1 Interface
        GUI.Label(new Rect(110, Screen.height - 75, 140, 100), "" + player1.coins);
        GUI.Label(new Rect(Screen.width / 2 + 110, Screen.height - 75, 140, 100), "" + player2.coins);

        /*GUI.Box(new Rect(10, Screen.height - 50, 50, 50), "x"+powerUps1.powerUps[0]);
        GUI.Box(new Rect(70, Screen.height - 50, 50, 50), "x" + powerUps1.powerUps[1]);
        GUI.Box(new Rect(130, Screen.height - 50, 50, 50), "x" + powerUps1.powerUps[2]);

        // Player2 Interface
        GUI.Label(new Rect(Screen.width - 140, Screen.height - 50, 140, 50), "Coins: " + player2.coins);

        GUI.Box(new Rect(Screen.width - 180, Screen.height - 50, 50, 50), "x" + powerUps2.powerUps[0]);
        GUI.Box(new Rect(Screen.width - 120, Screen.height - 50, 50, 50), "x" + powerUps2.powerUps[1]);
        GUI.Box(new Rect(Screen.width - 60, Screen.height - 50, 50, 50), "x" + powerUps2.powerUps[2]);*/

		if (showEndScreen) {
			GUI.Label(new Rect (Screen.width/2 - 100, Screen.height/2 - 50, 200, 100), "GAME OVER! ");
			if(GUI.Button(new Rect (Screen.width/2 - 100, Screen.height/2 + 50, 200, 100), "Play Again")) {
                
				Application.LoadLevel(0);                
			}
		}
	}

	void Update() {
		if (player1.coins <= 0) {
			EndGame ();
		}
		if (player2.coins <= 0) {
			EndGame ();
		}
		if (player1.coins >= winningCoins) {
            player1.coins = winningCoins;
			EndGame ();
		}
		if (player2.coins >= winningCoins) {
            player2.coins = winningCoins;
			EndGame ();
		}
	}

	void EndGame() {
		Time.timeScale = 0;
		showEndScreen = true;
	}
}
