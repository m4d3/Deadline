using UnityEngine;
using System.Collections;

public class KickBlockSpawner : MonoBehaviour
{
    public GameObject scroller;
    public GameObject kickBlock;
    public int leftPos;
    public int rightPos;
    public float spawnTime;
    public float timer = 2000;
    public bool activated = false;
    float spawnChance = 0;
    float spawnTimeBuffered;

    // Use this for initialization
    void Start()
    {
        spawnTimeBuffered = spawnTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (activated)
        {
            if (Random.value < spawnChance)
            {
                if (Random.value < 0.5)
                {
                    SpawnBlock(leftPos);
                }
                else
                {
                    SpawnBlock(rightPos);
                }
                spawnChance = 0;
            }
            spawnChance += (Time.deltaTime / timer);
            spawnTime -= Time.deltaTime;
            if (spawnTime <= 0)
            {
                spawnTime = spawnTimeBuffered;
                activated = false;
            }
        }
    }

    void SpawnBlock(int xPos)
    {
        GameObject newBlock = (GameObject)Instantiate(kickBlock, new Vector3(xPos, transform.position.y, 0), Quaternion.identity);
        newBlock.GetComponent<KickBlock>().leftPos = leftPos;
        newBlock.GetComponent<KickBlock>().rightPos = rightPos;
        newBlock.transform.parent = scroller.transform;
    }
}
