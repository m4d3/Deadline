using UnityEngine;
using System.Collections;
//using XInputDotNetPure;

public class PlayerCollision : MonoBehaviour {

	public int coins;		//coin counter
	public int collisionCost = 2;
	int coinCombo = 0;
	public int coinsForCombo = 10;
	int coinComboExtra = 0;
	public int coinsForMoreCombo = 3;
    public Animator coinInterfaceAnimator;

	void OnTriggerEnter2D(Collider2D col)
	{
        if (!GetComponent<Animator>().GetBool("Jumping"))
        {
            if (col.CompareTag("Coin"))
            {
                coins += 1 + coinComboExtra;
                coinInterfaceAnimator.GetComponent<Animator>().SetTrigger("Bounce");
                Destroy(col.gameObject);
                coinCombo++;
                if (coinCombo > coinsForCombo)
                {
                    //SendMessage ("GetNewCombo");
                    //GetComponent<PlayerControl>().GetNewCombo();
                    coinComboExtra = (coinCombo - coinsForCombo - coinsForMoreCombo) / coinsForMoreCombo;
                }
            }
            if (col.CompareTag("Block"))
            {
                coins -= collisionCost;
                
                Destroy(col.gameObject);
                coinCombo = 0;
                coinComboExtra = 0;
                //GamePad.SetVibration(0, 1, 1);
            }
        }

        if (col.CompareTag("Plane"))
        {
            coins -= collisionCost*2;

            Destroy(col.gameObject);
            coinCombo = 0;
            coinComboExtra = 0;
        }

        if (coins < 0)
        {
            coins = 0;
        }
	}
}
