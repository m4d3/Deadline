using UnityEngine;
using System.Collections;


public class PlayerControl : MonoBehaviour {

	//player1?
	public enum Players {player1, player2};
	public Players playerType;
	bool rightSide;
	public float jumpTime = 1;
	float jumpTimeBuffered;
	bool comboReady = false;
	public GameObject scroller;

	// Use this for initialization
	void Start () {
		jumpTimeBuffered = jumpTime;
		jumpTime = 0;
	}

	// Update is called once per frame
	void Update () {
		//if player 1 jumps
		if (Input.GetButtonDown ("Switch1") && playerType == Players.player1) {
			//check to which side to switch
			if (rightSide)
				transform.position = new Vector3(-7, transform.position.y, transform.position.z);
			else
				transform.position = new Vector3(-1, transform.position.y, transform.position.z);

			//invert right side
			rightSide = !rightSide;
		}
		//if player 2 jumps
		if (Input.GetButtonDown ("Switch2") && playerType == Players.player2) {
			//check to which side to switch
			if (rightSide)
				transform.position = new Vector3(1, transform.position.y, transform.position.z);
			else
				transform.position = new Vector3(7, transform.position.y, transform.position.z);

			//invert right side
			rightSide = !rightSide;
		}
		if (Input.GetButtonDown ("Jump1") && playerType == Players.player1 && jumpTime == 0) {
			Jump ();
		} else if (Input.GetButtonDown ("Jump2") && playerType == Players.player2 && jumpTime == 0) {
			Jump();
		}
		if (jumpTime > 0) {
			jumpTime -= Time.deltaTime;
		} else if (jumpTime < 0) {
			jumpTime = 0;
			gameObject.GetComponent<BoxCollider2D>().enabled = true;
			renderer.material.color = Color.white;
		}

		if (Input.GetButtonDown ("Combo1") && playerType == Players.player1 && comboReady) {
			UseCurrentCombo();
				}
		if (Input.GetButtonDown ("Combo2") && playerType == Players.player2 && comboReady) {
			UseCurrentCombo();
		}
	}

	void Jump() {

		jumpTime = jumpTimeBuffered;
		gameObject.GetComponent<BoxCollider2D>().enabled = false;
		renderer.material.color = Color.red;
	}

	public void GetNewCombo()
	{
		comboReady = true;
		renderer.material.color = Color.blue;
	}

	void UseCurrentCombo()
	{
		BombCombo ();
		comboReady = false;
	}

	void BombCombo()
	{
		foreach (Transform child in scroller.transform) {
			if (child.gameObject.CompareTag("Block"))
			{
				if (child.gameObject.GetComponent<Block>().playerNumber == 1 && playerType == Players.player1)
					Destroy(child.gameObject);

				else if (child.gameObject.GetComponent<Block>().playerNumber == 2 && playerType == Players.player2)
					Destroy(child.gameObject);
			}
		}
	}
}
