using UnityEngine;
using System.Collections;

public class KickBlock : Block {

    public int leftPos;
    public int rightPos;
    public float switchTimer = 1.0f;
    float switchTimerBuffered;

	// Use this for initialization
	void Start () {
        switchTimer = Random.value + 0.5f;
        switchTimerBuffered = switchTimer;
	}
	
	// Update is called once per frame
	void Update () {
        if (switchTimer > 0)
        {
            switchTimer -= Time.deltaTime;
        }
        else
        {
            if (transform.position.x == leftPos)
            {
                transform.position = new Vector3(rightPos, transform.position.y, 0);
            }
            else
            {
                transform.position = new Vector3(leftPos, transform.position.y, 0);
            }
            switchTimer = switchTimerBuffered;
        }
	}
}
