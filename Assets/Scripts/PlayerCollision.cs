using UnityEngine;
using System.Collections;
//using XInputDotNetPure;

public class PlayerCollision : MonoBehaviour {

	public int coins;		//coin counter
	public int collisionCost = 2;
	int coinCombo = 0;
	public int coinsForCombo = 10;

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.CompareTag("Coin"))
		{
			coins++;
			Destroy(col.gameObject);
			coinCombo++;
			if (coinCombo > coinsForCombo)
			{
				//SendMessage ("GetNewCombo");
				GetComponent<PlayerControl>().GetNewCombo();
				coinCombo = 0;
			}
		}
		if (col.CompareTag ("Block")) {
			coins -= collisionCost;
			if(coins < 0) {
				coins = 0;
			}
			Destroy (col.gameObject);
			coinCombo = 0;
			//GamePad.SetVibration(0, 1, 1);
		}
	}
}
