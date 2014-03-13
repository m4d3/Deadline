using UnityEngine;
using System.Collections;

public class Interface : MonoBehaviour {

	public PlayerCollision player1;
	public PlayerCollision player2;
	public GUISkin skin;

	public int winningCoins;

	bool showEndScreen = false;

    void Start()
    {
        Time.timeScale = 1;
        showEndScreen = false;
    }

	void OnGUI() {

		GUI.skin = skin;
		GUI.Label (new Rect (0,0,100,50), "Coins: "+player1.coins);
		GUI.Label (new Rect (Screen.width - 100,0,100,50), "Coins: "+player2.coins);

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
