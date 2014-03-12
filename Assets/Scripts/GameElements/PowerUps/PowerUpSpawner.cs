using UnityEngine;
using System.Collections;

public class PowerUpSpawner : MonoBehaviour {

	public float spawnTime = 10000;		//average times (in seconds) till next row of coins spawns
	float timeBuffered;
	float probSpawn = 0;					//probability for the next row of coins
	public GameObject powerUp1Prefab;
	public GameObject powerUp2Prefab;
	public GameObject powerUp3Prefab;
	GameObject[] powerUpPrefabs;
	public GameObject scroller;
	
	// Use this for initialization
	void Start () {
		timeBuffered = spawnTime;
		powerUpPrefabs = new GameObject[3];
		powerUpPrefabs [0] = powerUp1Prefab;
		powerUpPrefabs [1] = powerUp2Prefab;
		powerUpPrefabs [2] = powerUp3Prefab;
	}
	
	// Update is called once per frame
	void Update () {

		//generate a random percentage
		float random = Random.value * 100;
		
		//check if time out
		if (spawnTime > 0) {
			//subtract time intervall
			spawnTime -= Time.deltaTime;
			
			//check if triggered
			if (random <= probSpawn) {
				SpawnPowerUp ();
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
	}
	
	//spawn a power up
	void SpawnPowerUp()
	{
		int random = (int) (Random.value * 3);
		print (random);

		GameObject newCoin = (GameObject)Instantiate(powerUpPrefabs[random], transform.position, Quaternion.identity);
		newCoin.transform.parent = scroller.transform;
	}
}
