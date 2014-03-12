using UnityEngine;
using System.Collections;

public class BlockSpawner : MonoBehaviour {

	public enum Players{player1, player2};
	public Players playerEnum;				//enum player side
	public GameObject player;
	public GameObject scroller;
	public GameObject block;
	public int leftPos;
	public int rightPos;
	public int blockCost = 2;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetButtonDown ("LeftBlock1") && playerEnum == Players.player2) {
				SpawnBlock (leftPos);
		}
		if (Input.GetButtonDown ("LeftBlock2") && playerEnum == Players.player1) {
				SpawnBlock (leftPos);
		}
		if (Input.GetButtonDown ("RightBlock1") && playerEnum == Players.player2) {
				SpawnBlock (rightPos);
		}
		if (Input.GetButtonDown ("RightBlock2") && playerEnum == Players.player1) {
				SpawnBlock (rightPos);
		}
	}

	//spawn a single Blocj
	void SpawnBlock(int xPos)
	{
		if (player.GetComponent<PlayerCollision>().coins > blockCost) {
			GameObject newBlock = (GameObject)Instantiate (block, new Vector3 (xPos, 1.5f, 0), Quaternion.identity);
			//newBlock.transform.parent = scroller.transform;
			if (playerEnum == Players.player1)
				newBlock.GetComponent<Block>().playerNumber = 1;

			if (playerEnum == Players.player2)
				newBlock.GetComponent<Block>().playerNumber = 2;

			player.GetComponent<PlayerCollision>().coins -= blockCost;
		}
	}
}
