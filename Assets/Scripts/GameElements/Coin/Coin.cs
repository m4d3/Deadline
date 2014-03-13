using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour
{

    public float speed;

    GameObject player;
    bool isPulled = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isPulled)
        {
            transform.position = Vector3.Lerp(transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }

    public void Pull(GameObject playerObj)
    {
        transform.parent = null;
        player = playerObj;
        isPulled = true;
    }
}
