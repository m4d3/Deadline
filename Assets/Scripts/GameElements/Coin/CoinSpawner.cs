using UnityEngine;
using System.Collections;

public class CoinSpawner : MonoBehaviour {


	public float spawnTime = 20;		//average times (in seconds) till next row of coins spawns
	private float timeBuffered;
	int coinNumber = 0; 				//counter for coins
	bool spawningCoins = false;			 //spawning coins
	float probSpawn = 0;				//probability for the next row of coins
	float spawnTimeCounter = 0; 		//time counter for coin spawning
	public float spawnDistance = 1.0f;		//time between two coin spawns
	public GameObject coinPrefab;
	public GameObject scroller;

	// Use this for initialization
	void Start () {
		timeBuffered = spawnTime;
	}
	
	// Update is called once per frame
	void Update () {

		if (!spawningCoins) {
				//generate a random percentage
				float random = Random.value * 100;

				//check if time out
				if (spawnTime > 0) {
						//subtract time intervall
						spawnTime -= Time.deltaTime;

						//check if triggered
						if (random <= probSpawn) {
								SpawnCoins ();
								probSpawn = 0;
								spawnTime = timeBuffered;
						} else {
								//increase probability
								float scrollSpeed = scroller.GetComponent<Scroller>().scrollSpeed;
								probSpawn += 100 / timeBuffered * Time.deltaTime * scrollSpeed;
						}
				} else {
						//reset spawnTime
						spawnTime = timeBuffered;
				}
		} else {
			spawnTimeCounter += Time.deltaTime;
			float scrollSpeed = scroller.GetComponent<Scroller>().scrollSpeed;
			if (spawnTimeCounter > spawnDistance / scrollSpeed)
			{
				SpawnSingleCoin();
				//deacrease coin number
				coinNumber--;

				//reset time counter
				spawnTimeCounter = 0;

				//if coinNumber zero, change mode again
				if (coinNumber <= 0)
					spawningCoins = false;
			}
		}
	}

	//change to spawn mode
	void SpawnCoins()
	{
		//change Spawn mode
		spawningCoins = true;
		coinNumber = (int)Random.Range (1, 4);
	}

	//spawn a single coin
	void SpawnSingleCoin()
	{
		GameObject newCoin = (GameObject)Instantiate(coinPrefab, transform.position, Quaternion.identity);
		newCoin.transform.parent = scroller.transform;
		newCoin.transform.Rotate (new Vector3 (90, 0, 0));
	}
}
