using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {

	Transform scroller;
	public float fadeTime;
	public int playerNumber;	//for tracking which player it belongs to
    public Sprite[] startSprites;
    public Sprite[] blockSprites;
    public float targetPos;
    public float speed;

    float lerpStep = 0;
    int spriteNum = 0;
	Color transColor;
	Color fullColor;

	// Use this for initialization
	void Start () {
        spriteNum = (int)Random.Range(0, startSprites.Length);
		scroller = GameObject.Find ("Scroller").transform;

        GetComponent<SpriteRenderer>().sprite = startSprites[spriteNum];
	}
	
	// Update is called once per frame
	void Update () {
         

		if (fadeTime > 0) {
			fadeTime -= Time.deltaTime;
            lerpStep += Time.deltaTime * speed;
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, targetPos, transform.position.z), lerpStep);
		} else {
            GetComponent<SpriteRenderer>().sprite = blockSprites[spriteNum];
			transform.parent = scroller;
		}
	}
}
